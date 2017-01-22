using UnityEngine;
using System.Collections;

public class WavesController : MonoBehaviour {

    public GameObject wave_effect;
    private bool timehaspassed = true;
    private float timepassed = 0f;
    public float time_between_waves;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //wave creation
        if (timehaspassed)
        {
            timepassed = 0f;
            if (Input.GetMouseButton(0))
            {
                timehaspassed = false;
                timepassed += Time.deltaTime;
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
        else
        {
            timepassed += Time.deltaTime;
            if (timepassed > time_between_waves)
            {
                timehaspassed = true;
            }
        }
	}
}
