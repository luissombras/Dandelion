﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour {

	[SerializeField] float speed;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
        //Initial velocity, works weel with vrey low linear drag in rigid body
        rb.velocity = new Vector2(0, speed);
    }
	
	// Update is called once per frame
	void Update () {
        //small force pushing it down
        rb.AddForce(new Vector2(0f, -0.1f), ForceMode2D.Force);
		
	}
}