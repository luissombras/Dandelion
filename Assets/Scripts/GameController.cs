using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public static string ON_PAUSE = "OnPause";
	public static string ON_RESUME = "OnResume";
	public static string ON_PLAYER_DEAD = "OnPlayerDead";
    public static string ON_WIN = "OnWin";

    [SerializeField] private GameObject gamePanel;
	[SerializeField] private GameObject pausePanel;
	[SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;

	// NOTIFIER
	private Notifier notifier;
	private bool paused = false;

	void Start () 
    {
		// NOTIFIER
		notifier = new Notifier ();
		notifier.Subscribe(ON_PAUSE, HandlePause);
		notifier.Subscribe(ON_RESUME, HandleResume);	
		notifier.Subscribe(ON_PLAYER_DEAD, HandlePlayerDead);
        notifier.Subscribe(ON_WIN, HandlePlayerWin);
    }

	public void OnPause()
	{
		if (paused)
		{
			notifier.Notify(GameController.ON_RESUME);
		}
		else
		{
			notifier.Notify(GameController.ON_PAUSE);
		}
		paused = !paused;
	}

	private void HandlePause (params object[] args) 
    {
		Time.timeScale = 0;
		pausePanel.SetActive (true);
		pausePanel.transform.SetAsLastSibling ();
	}

	private void HandleResume (params object[] args) 
    {
		Time.timeScale = 1;
		pausePanel.SetActive (false);
		gamePanel.transform.SetAsLastSibling ();
	}

	private void HandlePlayerDead (params object[] args) 
    {
		Time.timeScale = 0;
		losePanel.SetActive (true);
		losePanel.transform.SetAsLastSibling ();
	}


    private void HandlePlayerWin(params object[] args)
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
        winPanel.transform.SetAsLastSibling();
    }

	public void RetryAction () 
    {
		AppManager.Instance.RestartCurrentScene ();
	}

	public void ExitAction () 
    {
        AppManager.Instance.ChangeScene("MainMenu");
	}

	public void PauseAction () 
    {
		this.OnPause ();
	}

	public void ResumeAction () 
    {
		this.OnPause ();
	}

	// NOTIFIER
	void OnDestroy () 
    {
		if (notifier != null) 
        {
			notifier.UnsubcribeAll ();
		}
	}
}
