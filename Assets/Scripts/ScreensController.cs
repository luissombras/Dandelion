using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreensController : MonoBehaviour {

	// NOTIFIER
	private Notifier notifier;
	public static string ON_PLAYER_DEAD = "OnPlayerDead";
	public static string ON_PAUSE = "OnPause";
	public static string ON_RESUME = "OnResume";
    public static string ON_WIN = "OnWin";

    [SerializeField] private GameObject gamePanel;
	[SerializeField] private GameObject pausePanel;
	[SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject WinPanel;

	// Use this for initialization
	void Start () {
		// NOTIFIER
		notifier = new Notifier ();
		notifier.Subscribe(ON_PAUSE, HandlePause);
		notifier.Subscribe(ON_RESUME, HandleResume);	
		notifier.Subscribe(ON_PLAYER_DEAD, HandlePlayerDead);
        notifier.Subscribe(ON_WIN, HandlePlayerWin);
    }

	private void HandlePause (params object[] args) {
		Time.timeScale = 0;
		pausePanel.SetActive (true);
		pausePanel.transform.SetAsLastSibling ();
	}

	private void HandleResume (params object[] args) {
		Time.timeScale = 1;
		pausePanel.SetActive (false);
		gamePanel.transform.SetAsLastSibling ();
	}

	private void HandlePlayerDead (params object[] args) {
		Time.timeScale = 0;
		deathPanel.SetActive (true);
		deathPanel.transform.SetAsLastSibling ();
	}

    private void HandlePlayerWin(params object[] args)
    {
        Time.timeScale = 0;
        WinPanel.SetActive(true);
        WinPanel.transform.SetAsLastSibling();
    }

    // NOTIFIER
    void OnDestroy () {
		if (notifier != null) {
			notifier.UnsubcribeAll ();
		}
	}
}
