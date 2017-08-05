using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpeedController : MonoBehaviour 
{
    [SerializeField] bool isStart = false; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isStart)
        {
            CameraMovement.isActive = true;
        } else 
        {
			if (other.tag == "Player")
			{
				Debug.Log("Speed Up!");
				Camera2DFollowY.Disable();
				CameraMovement.SpeedUpCamera(0.7f);
				FrogController.FrogSpeedUp(0.4f);
			}
		}
    }

}
