using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwirlController : MonoBehaviour {

    private Rigidbody2D player_rb;
    private Vector2 swirl_pos;
    private Vector2 frog_pos;
    private Vector2 radial;
    public float cntr_force;
    public float perp_force;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            player_rb = coll.gameObject.GetComponent<Rigidbody2D>();
            frog_pos = new Vector2(coll.gameObject.transform.position.x, coll.gameObject.transform.position.y);
            swirl_pos = new Vector2(transform.position.x, transform.position.y);

            //central force
            radial = swirl_pos - frog_pos;
            //radial


            //player_rb.AddForce
        }
        
    }
}
