using UnityEngine;
using System.Collections;

public class WavesController : MonoBehaviour {

    public GameObject wave_effect;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //wave creation
        if (Input.GetMouseButtonDown(0))
        {
            
            //Instaciate wave at mouse click
            Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse_pos.Set(mouse_pos.x, mouse_pos.y, 0f);
            //Debug.Log(mouse_pos.x + " " + mouse_pos.y);
            GameObject wave = Instantiate(wave_effect, mouse_pos, Quaternion.identity) as GameObject;

            //Scale wave

            //Wave destruction
            float delay = 5; //seconds
            Destroy(wave, delay);
        }
	}
}
