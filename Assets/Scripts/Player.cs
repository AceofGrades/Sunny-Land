using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prime31;

public class Player : MonoBehaviour {

	public float moveSpeed = 10f;
	public float gravity = -9.81f;

	private CharacterController2D controller;

    void Start() {

		controller = GetComponent<CharacterController2D>();    
    }

    void Update() {

		float inputH = Input.GetAxis("Horizontal");
		float inputV = Input.GetAxis("Vertical");

		controller.move(transform.right * inputH * moveSpeed * Time.deltaTime);
    }
}
