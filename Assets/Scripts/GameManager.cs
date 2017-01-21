using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// NOTIFIER
	private Notifier notifier;
	//public static string ON_PLAYER_DEAD = "OnPlayerDead";

	// Use this for initialization
	void Start () {
		// NOTIFIER
		notifier = new Notifier ();
		//notifier.Subscribe(ON_PLAYER_DEAD, HandlePlayerDead);	
	}

	private void HandlePlayerDead (params object[] args) {
		
	}

	public void RestartCurrentScene () {
		int scene = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}

	public void GotoScene (int scene) {
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
