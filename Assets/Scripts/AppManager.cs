﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : Singleton<AppManager> 
{
    [SerializeField] private string baseLevel;
	[SerializeField] private AudioClip[] sceneLoops;
    [SerializeField] private bool iAmFirst;

    private int lastSceneIndex;
    private int lastLevelIndex;
	// NOTIFIER
	private Notifier notifier;	

	void Awake() 
    {
		DontDestroyOnLoad(Instance);
		AppManager[] gameManagers = FindObjectsOfType(typeof(AppManager)) as AppManager[];
		if(gameManagers.Length > 1) 
        {
			for(int i = 0; i < gameManagers.Length; i++) 
            {
				if(!gameManagers[i].iAmFirst) 
                {
					DestroyImmediate(gameManagers[i].gameObject);
				}
			}
		} else 
        {
			iAmFirst = true;
		}
	}

	void Start () 
    {
		// NOTIFIER
		notifier = new Notifier ();
	}

	void OnEnable() 
    {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable() 
    {
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	public void ChangeScene(string scene)
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}

	public void RestartCurrentScene () 
    {
		Time.timeScale = 1;
		int scene = SceneManager.GetActiveScene ().buildIndex;
        ScoreController.ScoreReset();
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
        if (lastSceneIndex != 0){
            SceneManager.LoadScene(lastLevelIndex, LoadSceneMode.Additive);
		}
	}

	public void LoadLevel (string level) 
    {
		Time.timeScale = 1;
        SceneManager.LoadScene(baseLevel, LoadSceneMode.Single);
        SceneManager.LoadScene(level, LoadSceneMode.Additive);
	}

	public void QuitApplication () 
    {
		Application.Quit ();
	}
	
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
        switch (mode) {
            case LoadSceneMode.Additive:
                Debug.Log("Level Loaded: " + scene.name);
                lastLevelIndex = scene.buildIndex;
                break;
            case LoadSceneMode.Single:
                Debug.Log("Current scene: " + scene.name);
				lastSceneIndex = scene.buildIndex;
                StopAudioLoop(lastSceneIndex);
                StartAudioLoop(scene.buildIndex);
                //Debug.Log("Last scene: " + lastSceneIndex);
				break;
            default:
				Debug.Log("Current scene: " + scene.name);
				StartAudioLoop(scene.buildIndex);
                break;
        }
	}

	private void StartAudioLoop(int sceneIndex)
	{
		AudioManager.Instance.PlayLoop2D("Scene_" + sceneIndex.ToString(), sceneLoops[sceneIndex]);
	}

	private void StopAudioLoop(int sceneIndex)
	{
		AudioManager.Instance.StopLoop("Scene_" + sceneIndex.ToString());
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
