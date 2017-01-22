using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	[SerializeField] private float speed;
    private static float speed_update;

    // Use this for initialization
    void Start () {
        speed_update = speed;
    }
	
	// Update is called once per frame
	void LateUpdate () {		
		transform.Translate (Vector2.down * Time.deltaTime * speed_update);
	}

    public static void speedUpCamera(float speed_increase)
    {
        speed_update += speed_increase;
    }

    public static void speedDownCamera(float speed_increase)
    {
        speed_update -= speed_increase;
    }


}
