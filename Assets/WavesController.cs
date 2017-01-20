using UnityEngine;
using System.Collections;

public class WavesController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject[] movables;
            movables = GameObject.FindGameObjectsWithTag("wave_movable");

            for(int i = 0; i < movables.Length; i++)
            {
                Debug.Log("Created Wave " + i + " " + movables[i].GetType());
            }
        }
	}
}
