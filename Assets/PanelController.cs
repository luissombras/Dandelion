using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {

	[SerializeField] private bool startVisible = false;

	// Use this for initialization
	void Awake () {
		gameObject.SetActive (startVisible);
	}
}
