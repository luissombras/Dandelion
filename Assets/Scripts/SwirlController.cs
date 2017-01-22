using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwirlController : MonoBehaviour {

    private Rigidbody2D player_rb;
    private Vector2 swirl_pos;
    private Vector2 frog_pos;
    private Vector2 radial;
    private Vector2 perpendicular;
    public float swirl_velocity;
    public float cntr_force;
    public float perp_force;

	// NOTIFIER
	private Notifier notifier;

    // Use this for initialization
    void Start () {
		// NOTIFIER
		notifier = new Notifier();
	}
	
	// Update is called once per frame
	void Update () {
        //rotate swirl image
        transform.Rotate(Vector3.forward * Time.deltaTime* swirl_velocity);
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player") || coll.gameObject.tag.Equals("swirl_movable"))
        {
            player_rb = coll.gameObject.GetComponent<Rigidbody2D>();
            frog_pos = new Vector2(coll.gameObject.transform.position.x, coll.gameObject.transform.position.y);
            swirl_pos = new Vector2(transform.position.x, transform.position.y);

            //central force pointing inwards
            radial = swirl_pos - frog_pos;
            float magnitude = Vector3.Magnitude(radial);
            radial.Normalize();
            //Debug.Log(magnitude);
            if(magnitude < 0.5)
            {
                Invoke("enterTheVoid", 1);
            }
            player_rb.AddForce(cntr_force * radial / Mathf.Pow(magnitude,1.5f), ForceMode2D.Force);

            //perpendicular force
            perpendicular = new Vector2(0f, 0f);
            if (swirl_velocity < 0f)
            {
                perpendicular = new Vector2(-radial.y, radial.x);
            } 
            if(swirl_velocity > 0f)
            {
                perpendicular = new Vector2(radial.y, -radial.x);
            }
            
            //Debug.Log(perpendicular);
            player_rb.AddForce(perp_force * perpendicular, ForceMode2D.Force);
        }
        
    }

    void enterTheVoid()
    {
        Debug.Log("DEATH");
		notifier.Notify (ScreensController.ON_PLAYER_DEAD);
    }

	// NOTIFIER
	void OnDestroy () {
		if (notifier != null) {
			notifier.UnsubcribeAll ();
		}
	}
}
