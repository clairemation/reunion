﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderMovement : BaseMovement {

	[SerializeField] float speed = 0.05f;
	[SerializeField] float angle = 25f;

	Vector3 direction;
	Collider2D collider;


	void Awake(){
		collider = GetComponent<Collider2D> ();
	}

	void OnEnable(){
		Init();
	}

	void Init(){
		direction = (Quaternion.Euler (0f, 0f, angle) * Vector3.right);
		direction.Normalize ();
	}

	void FixedUpdate () {
		transform.position += direction * speed;
	}

	public void SetRandomDirection(){
		direction = RandomDirection ();
	}

	Vector3 RandomDirection(){
		Vector3 direction = Quaternion.Euler (0f, 0f, Random.Range (0f, 360f)) * Vector3.right;
		direction.Normalize ();
		return direction;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Obstacle")) {
			direction = Vector3.Reflect (direction, col.GetContact (0).normal);
		}
	}
}
