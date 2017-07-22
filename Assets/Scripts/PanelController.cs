using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour 
{

	[SerializeField] private bool startVisible = false;

	void Awake () 
    {
		gameObject.SetActive (startVisible);
	}
}
