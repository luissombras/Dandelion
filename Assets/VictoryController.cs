using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryController : MonoBehaviour {

    // NOTIFIER
    private Notifier notifier;

    // Use this for initialization
    void Start () {
        // NOTIFIER
        notifier = new Notifier();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            notifier.Notify(ScreensController.ON_WIN);
        }
    }

    // NOTIFIER
    void OnDestroy()
    {
        if (notifier != null)
        {
            notifier.UnsubcribeAll();
        }
    }
}
