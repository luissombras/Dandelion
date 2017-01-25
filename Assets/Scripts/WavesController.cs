using UnityEngine;
using System.Collections;

public class WavesController : MonoBehaviour {

    public GameObject wave_effect;
    private bool timehaspassed = true;
    private float timepassed = 0f;
    public float time_between_waves;

	private bool active = true;
	// NOTIFIER
	private Notifier notifier;

    // Use this for initialization
    void Start () {
		// NOTIFIER
		notifier = new Notifier ();
		notifier.Subscribe(ScreensController.ON_PAUSE, HandleInactive);
		notifier.Subscribe(ScreensController.ON_RESUME, HandleActive);	
		notifier.Subscribe(ScreensController.ON_PLAYER_DEAD, HandleInactive);

		active = true;
	}

	private void HandleActive (params object[] args) {
		active = true;
	}

	private void HandleInactive (params object[] args) {
		active = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			//wave creation
			if (timehaspassed) {
				timepassed = 0f;
				if (Input.GetMouseButton (0) || Input.touchCount > 0) {
					timehaspassed = false;
					timepassed += Time.deltaTime;
                    //Instaciate wave at mouse click
                    Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    // IF touch controlls, it instaciates at touch position
                    if (Input.touchCount > 0)
                    {
                        mouse_pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    }
					mouse_pos.Set (mouse_pos.x, mouse_pos.y, 0f);
					//Debug.Log(mouse_pos.x + " " + mouse_pos.y);
					GameObject wave = Instantiate (wave_effect, mouse_pos, Quaternion.identity) as GameObject;

					//Scale wave

					//Wave destruction
					float delay = 5; //seconds
					Destroy (wave, delay);
				}
			} else {
				timepassed += Time.deltaTime;
				if (timepassed > time_between_waves) {
					timehaspassed = true;
				}
			}
		}
	}

	// NOTIFIER
	void OnDestroy () {
		if (notifier != null) {
			notifier.UnsubcribeAll ();
		}
	}
}
