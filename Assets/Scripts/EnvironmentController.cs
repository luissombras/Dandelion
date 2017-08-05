using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour {

    public AudioClip river;
	// Use this for initialization
	void Start () {
        AudioManager.Instance.PlayLoop2D("River FX", river);
	}
}
