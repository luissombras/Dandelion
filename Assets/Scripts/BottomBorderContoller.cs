using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBorderContoller : MonoBehaviour 
{

    public int border_place;//1 - Left, 2 - Bottom, 3 Right

    private Vector3 screen_pos;

    void Start () 
    {
        float cam_height = 2f * Camera.main.orthographicSize;
        float cam_width = cam_height * Camera.main.aspect;
        //adtapts if left and right camera limits are smaller than play space
        if (border_place == 1 && cam_width / 2 <= Mathf.Abs(transform.position.x))
        {
            screen_pos = new Vector3(-cam_width/2, transform.position.y, transform.position.z);
        } else if (border_place == 3 && cam_width / 2 <= transform.position.x)
        {
            screen_pos = new Vector3(cam_width/2, transform.position.y, transform.position.z);
        } else
        {
            screen_pos = transform.position;
        }
    }
	
	void Update () 
    {
        transform.position = Camera.main.transform.position + screen_pos;
	}
}
