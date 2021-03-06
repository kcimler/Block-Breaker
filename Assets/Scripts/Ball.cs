﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted){
			// lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			// mouse press will launch ball
			if (Input.GetMouseButtonDown(0)){
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (2f, 10f);
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision ){
		Vector2 tweak = new Vector2 (Random.Range (-0.3f, .3f), Random.Range(-.3f, .3f)); //AUTOPLAY
		if (hasStarted){
			audio.Play();
			rigidbody2D.velocity += tweak;
		}
	}
}
