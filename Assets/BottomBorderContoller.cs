using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBorderContoller : MonoBehaviour {

    private Vector3 bottom_screen_pos;

    // Use this for initialization
    void Start () {
        bottom_screen_pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Camera.main.transform.position + bottom_screen_pos;
	}
}
