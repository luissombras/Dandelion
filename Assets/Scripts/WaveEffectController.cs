﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEffectController : MonoBehaviour {

    public float wave_speed;
    public float wave_power;
    public float max_wave_power;
    private Vector3 mouse_pos;

    // Use this for initialization
    void Start () {
        //mouse position on creation
        mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse_pos.Set(mouse_pos.x, mouse_pos.y, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(transform.localScale.x + wave_speed * Time.deltaTime, transform.localScale.y + wave_speed * Time.deltaTime, 1f);
        Color color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r,
                                gameObject.GetComponent<SpriteRenderer>().color.g,
                                gameObject.GetComponent<SpriteRenderer>().color.b,
                                gameObject.GetComponent<SpriteRenderer>().color.a*(1-wave_speed*Time.deltaTime*0.1f));
        Debug.Log(Time.deltaTime);
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Wave. Started Colision");
        //colision point
        Vector3 coliding_obj_pos = coll.gameObject.transform.position;
        Vector2 radial = new Vector2(coliding_obj_pos.x - mouse_pos.x, coliding_obj_pos.y - mouse_pos.y);
        float magnitude = Vector3.Magnitude(radial);

<<<<<<< HEAD
        //Debug.Log("wave magnitude " + magnitude);
=======
        //Debug.Log(magnitude);
>>>>>>> ebaaaea9693a78d81b3273ab6185ad9559cc592e
        //for direction
        radial.Normalize();
        //magnitude balance
        magnitude = Mathf.Clamp(wave_power/Mathf.Pow(magnitude, 2),0f, max_wave_power);
        coll.gameObject.GetComponent<Rigidbody2D>().AddForce(magnitude*radial, ForceMode2D.Impulse);
    }
}