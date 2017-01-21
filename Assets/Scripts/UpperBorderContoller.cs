using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperBorderContoller : MonoBehaviour {

    private Vector3 upper_screen_pos;

	// NOTIFIER
	private Notifier notifier;

    // Use this for initialization
    void Start()
    {
		// NOTIFIER
		notifier = new Notifier();
        upper_screen_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.transform.position + upper_screen_pos;
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			Debug.Log ("Frog Died!!");
			notifier.Notify (ScreensControl.ON_PLAYER_DEAD);
			Destroy (other.gameObject);
		}
	}
}
