using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{

    [SerializeField] private float speed = 1.0f;
    private static float speedUpdate;
    public static bool isActive = false;

    void Start () 
    {
        speedUpdate = speed;
    }
	
	void LateUpdate () 
    {
        if (isActive)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speedUpdate);    
        }
	}

    public static void SpeedUpCamera(float speedIncrease)
    {
        speedUpdate += speedIncrease;
    }

    public static void SpeedDownCamera(float speedIncrease)
    {
        speedUpdate -= speedIncrease;
    }


}
