﻿using UnityEngine;
using System.Collections;

//not responsible for causeing the character to animate or tell it what state it is in
//script is just here for updating parameters

public class LinkControllerScript : MonoBehaviour {
	public float maxSpeed = 10f;
	bool facingRight = true;
	Rigidbody2D myBody;

	Quaternion rotation;

	Animator anim;

	//used for ground
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask WhatisGround;
	public float jumpForce = 700;


	//public bool doubleJump = false;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myBody = GetComponent<Rigidbody2D>();
	
	}

 

	// FixedUpdate is called once per fixed frame
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, WhatisGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", myBody.velocity.y);


		float move = Input.GetAxis ("Horizontal");


		if (Input.GetKeyDown (KeyCode.A)) {
			{
				this.gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0, 270, 0));
				{Debug.Log ("Rotated left");}
			}
		}

		if (Input.GetKeyDown (KeyCode.D)) {
			{
				this.gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0, 90, 0));
				{Debug.Log ("Rotated right");}
			}
		}

		anim.SetFloat ("Speed", Mathf.Abs (move));

		myBody.velocity = new Vector2 (move * maxSpeed, myBody.velocity.y);

	}


	void Update()
	{

			//double jump coding
		//if ((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.Space))

		if (grounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			anim.SetBool ("Ground", false);
			myBody.AddForce (new Vector2 (0, jumpForce));
 
		} 
	}
 
}

