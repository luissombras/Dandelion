using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryController : MonoBehaviour 
{
    // NOTIFIER
    private Notifier notifier;

    // Use this for initialization
    void Start () 
    {
        // NOTIFIER
        notifier = new Notifier();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            notifier.Notify(GameController.ON_WIN);
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
