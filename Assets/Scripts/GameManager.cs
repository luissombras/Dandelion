using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject wavesInput;

	private bool paused = false;
	// NOTIFIER
	private Notifier notifier;

	// Use this for initialization
	void Start () {
		// NOTIFIER
		notifier = new Notifier ();
	}

	public void OnPause () {
		if (paused) {
			notifier.Notify (ScreensController.ON_RESUME);
			wavesInput.SetActive (true);
		} else {
			notifier.Notify (ScreensController.ON_PAUSE);
			wavesInput.SetActive (false);
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
