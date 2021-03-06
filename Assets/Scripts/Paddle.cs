﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

//.5f 15.5f
	public bool autoPlay = false;
	
	public Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType <Ball>();
		print (ball);
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay){
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	// Paddle will follow ball automatically
	
	void AutoPlay () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, .5f, 15.5f);
		this.transform.position = paddlePos;
	}
	
	// Paddle will be controlled manually
	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, .5f, 15.5f);
		this.transform.position = paddlePos;
	}
}
