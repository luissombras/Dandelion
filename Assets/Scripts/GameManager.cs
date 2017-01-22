using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

	[SerializeField] private AudioClip[] sceneLoops;

	private bool paused = false;
	private int lastSceneIndex;

	// NOTIFIER
	private Notifier notifier;

	public bool iAmFirst;

	void Awake()
	{
		DontDestroyOnLoad(Instance);

		GameManager[] gameManagers = FindObjectsOfType(typeof(GameManager)) as GameManager[];

		if(gameManagers.Length > 1)
		{
			for(int i = 0; i < gameManagers.Length; i++)
			{
				if(!gameManagers[i].iAmFirst)
				{
					DestroyImmediate(gameManagers[i].gameObject);
				}
			}
		}
		else
		{
			iAmFirst = true;
		}
	}

	// Use this for initialization
	void Start () {
		// NOTIFIER
		notifier = new Notifier ();
	}

	void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		Debug.Log("Level Loaded: "+scene.name);
		Debug.Log ("Current scene: " + scene.buildIndex);
		Debug.Log ("Last scene: " + lastSceneIndex);

		StopAudioLoop (lastSceneIndex);
		StartAudioLoop (scene.buildIndex);
		lastSceneIndex = scene.buildIndex;
	}

	private void StartAudioLoop (int sceneIndex) {
		//int scene = SceneManager.GetActiveScene ().buildIndex;
		AudioManager.Instance.PlayLoop2D ("Scene_"+sceneIndex.ToString(), sceneLoops [sceneIndex]);
	}

	private void StopAudioLoop (int sceneIndex) {
		//int scene = SceneManager.GetActiveScene ().buildIndex;
		AudioManager.Instance.StopLoop ("Scene_"+sceneIndex.ToString());
	}

	public void OnPause () {
		if (paused) {
			notifier.Notify (ScreensController.ON_RESUME);
		} else {
			notifier.Notify (ScreensController.ON_PAUSE);
		}
		paused = !paused;
	}

	public void RestartCurrentScene () {
		Time.timeScale = 1;
		int scene = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}

	public void GotoScene (int scene) {
		Time.timeScale = 1;
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}

	public void QuitApplication () {
		Application.Quit ();
	}

	// NOTIFIER
	void OnDestroy () {
		if (notifier != null) {
			notifier.UnsubcribeAll ();
		}
	}
}
