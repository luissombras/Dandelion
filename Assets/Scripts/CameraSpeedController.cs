using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpeedController : MonoBehaviour 
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Speed Up!");
            Camera2DFollowY.disable();
            CameraMovement.speedUpCamera(0.7f);
            FrogController.frogSpeedUp(0.4f);
        }
    }
}
