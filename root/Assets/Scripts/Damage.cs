﻿using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	// Use this for initialization
	 public int damage = 100;

	/*
	void Start()
	{
		if(Player == null)
			Player = GameObject.FindGameObjectWithTag ("Player");
	}
	*/
     void OnTriggerEnter2D()
     {
        // if(gameObject.CompareTag("Player"))
            Player.GetComponent<PlayerStats>().currentHealth -= damage;
     }
	
	// Update is called once per frame
	void Update () {

	
	}
    [SerializeField]
    GameObject Player;
}
