using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperBorderContoller : MonoBehaviour {

    private Vector3 upper_screen_pos;

    // Use this for initialization
    void Start()
    {
        upper_screen_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.transform.position + upper_screen_pos;
    }
}
