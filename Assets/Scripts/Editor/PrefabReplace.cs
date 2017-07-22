using UnityEngine;
using UnityEditor;
using System.Collections;

public class PrefabReplace : EditorWindow
{
	public Object Prefab;

	[MenuItem("Tools/Replace With Prefab")]
	static void Init()
	{
		EditorWindow window = EditorWindow.GetWindow(typeof(PrefabReplace));
		window.Show();
	}

	private void OnGUI()
	{
		EditorGUILayout.BeginHorizontal();

		GUILayout.Label("Prefab");

		if (Prefab != null)
		{
			Prefab = EditorGUI.ObjectField(Rect.MinMaxRect(50, 0, 200, 16), ((GameObject)Prefab).name, Prefab, typeof(GameObject), true);
		}
		else
		{
			Prefab = EditorGUI.ObjectField(Rect.MinMaxRect(50, 0, 200, 16), Prefab, typeof(GameObject), true);
		}

		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();

		if (GUILayout.Button("Replace Selected Objects", GUILayout.Width(180f)))
		{
			Replace();
		}

		EditorGUILayout.EndHorizontal();
	}

	void Replace()
	{
		if(Prefab == null)
		{
			Debug.LogError("No prefab given");
			return;
		}

		GameObject instance = null;
		for(int i = Selection.gameObjects.Length - 1; i >= 0; i--)
		{
			instance = (GameObject)PrefabUtility.InstantiatePrefab(Prefab);

			Undo.RegisterCreatedObjectUndo(instance, "replaceObject" + i);

			instance.transform.parent = Selection.gameObjects[i].transform.parent;
			instance.transform.position = Selection.gameObjects[i].transform.position;
			instance.transform.rotation = Selection.gameObjects[i].transform.rotation;
			instance.transform.localScale = Selection.gameObjects[i].transform.localScale;

			Undo.DestroyObjectImmediate(Selection.gameObjects[i]);
		}

		Debug.Log("Replace Successful");
	}
}