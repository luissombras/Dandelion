﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreensControl : MonoBehaviour {

	// NOTIFIER
	private Notifier notifier;
	public static string ON_PLAYER_DEAD = "OnPlayerDead";

	[SerializeField] private GameObject gamePanel;
	[SerializeField] private GameObject deathPanel;

	// Use this for initialization
	void Start () {
		// NOTIFIER
		notifier = new Notifier ();
		notifier.Subscribe(ON_PLAYER_DEAD, HandlePlayerDead);	
	}

	private void HandlePlayerDead (params object[] args) {
		Time.timeScale = 0;
		deathPanel.SetActive (true);
		deathPanel.transform.SetAsLastSibling ();
	}

	public void RestartCurrentScene () {
		Time.timeScale = 1;
		int scene = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}

	public void GotoScene (int scene) {
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// NOTIFIER
	void OnDestroy () {
		if (notifier != null) {
			notifier.UnsubcribeAll ();
		}
	}
}