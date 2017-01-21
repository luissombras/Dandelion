using UnityEngine;
using System.Collections;

public class WavesController : MonoBehaviour {

    public GameObject wave_effect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            float delay = 5; //seconds
            Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mouse_pos.x + " " + mouse_pos.y);
            GameObject wave = Instantiate(wave_effect, mouse_pos, Quaternion.identity) as GameObject;
            Destroy(wave, delay);
        }
	}
}
