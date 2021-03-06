﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 10, jumpVelocity = 10;
	public LayerMask playerMask;
	public bool canMoveInAir = true;
	Transform myTrans, tagGround;
	Rigidbody2D myBody;
	[SerializeField]
	private Animator _anim;

	bool isGrounded = false;

	void Awake()
	{
		//grab the animator from the gameobject that this script is attached to
		_anim = this.GetComponent<Animator> ();
		
	}
	
	void Start ()
	{
		myBody = GetComponent<Rigidbody2D>();
		myTrans = this.transform;
		tagGround = GameObject.Find (this.name + "/tag_ground").transform;
	}

	
	void FixedUpdate ()
	{
		
		isGrounded = Physics2D.Linecast (myTrans.position, tagGround.position, playerMask);
		
		Move (Input.GetAxisRaw ("Horizontal"));
		if (Input.GetButtonDown ("Jump"))
		   	Jump ();

		if (Input.GetKeyDown (KeyCode.D))
		{
			{
				_anim.SetBool ("right", false);
				this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 200, 0));
			}
			
			Debug.Log("face right");
		}

		if (Input.GetKeyUp (KeyCode.D)) 
		{
			{
				_anim.SetBool ("idle", true);
			}
			Debug.Log ("IdleRight");
		}

		if (Input.GetKeyDown (KeyCode.A))
		{
			{
				_anim.SetBool ("left", true);
				this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
			}
			
			Debug.Log("face left");
		}

		if (Input.GetKeyUp (KeyCode.A)) 
		{
			{
				_anim.SetBool ("idle", true);
			}
			Debug.Log("IdleLeft");
		}

	}


	void Move(float horizontalInput)
	{
		if(!canMoveInAir && !isGrounded)
			return;
		
		Vector2 moveVel = myBody.velocity;
		moveVel.x = horizontalInput * speed;
		myBody.velocity = moveVel;
	}

	public void Jump()
	{
		if (isGrounded)
			myBody.velocity += jumpVelocity * Vector2.up;
	}

}