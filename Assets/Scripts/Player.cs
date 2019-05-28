using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prime31;

public class Player : MonoBehaviour {

	public float moveSpeed = 10f;
	public float gravity = -9.81f;
    public Animator anim;

	private CharacterController2D controller;

    void Start() {

		controller = GetComponent<CharacterController2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {

		float inputH = Input.GetAxis("Horizontal");
		float inputV = Input.GetAxis("Vertical");

        Move(inputH, inputV);
    }

    void Move(float inputH, float inputV)
    {
        controller.move(transform.right * inputH * moveSpeed * Time.deltaTime);
        bool IsRunning = inputH != 0;
        anim.SetBool("IsRunning", IsRunning);

        // rend.flipX = inputH > 0
    }

    void Climb(float inputV)
    {

    }
}
