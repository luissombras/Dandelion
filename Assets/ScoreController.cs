﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    private Text text_score;
    static float score;

	// Use this for initialization
	void Start () {
        score = 0;
        text_score = gameObject.GetComponent<Text>();
        text_score.text = score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        text_score.text = score.ToString();
    }

    public static void ScoreAdd()
    {
        score = score + 1;
    }
}