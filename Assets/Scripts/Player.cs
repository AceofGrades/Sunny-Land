using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prime31;

public class Player : MonoBehaviour {

	public float moveSpeed = 10f;
	public float gravity = -10f;
    public float jumpHeight = 7f;
    public float centreRadius = .1f;

    private SpriteRenderer rend;
    public Animator anim;

	private CharacterController2D controller;
    private Vector3 velocity;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, centreRadius);
    }

    void Start() {

		controller = GetComponent<CharacterController2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        // Getting left and right key inputs
		float inputH = Input.GetAxis("Horizontal");
        // Getting up and down key inputs
		float inputV = Input.GetAxis("Vertical");
        // If character is NOT grounded
        if (!controller.isGrounded)
        {
            // Apply delta to gravity
            velocity.y += gravity * Time.deltaTime;
        }

        // Get Spacebar input
        bool isJumping = Input.GetButtonDown("Jump");
        // If Player pressed Jump
        if (isJumping)
        {
            // Make controller jump
            Jump();
        }

        // Animate player to Idle if player is grounded
        anim.SetBool("IsGrounded", controller.isGrounded);
        // Animate player to Jump if input for jump is pressed
        anim.SetFloat("JumpY", velocity.y);

        Run(inputH);
        Climb(inputV);

        // Applies velocity to controller (get it to move)
        controller.move(velocity * Time.deltaTime);
    }

    void Run(float inputH)
    {
        // Move the character controller left / right with input
        velocity.x = inputH * moveSpeed;

        // Animate player to running if input is pressed
        anim.SetBool("IsRunning", inputH != 0);

        // Checks if button has been pressed
        if(inputH != 0)
        {
            // Character will flip if inputH is less than 0
            rend.flipX = inputH < 0;
        }
    }

    void Climb(float inputV)
    {
        bool isOverLadder = false; // Is overlapping ladder
        bool isClimbing = false; // Is in climbing state

        // Get list of all hit objects overlapping point
        Collider2D[] hits = Physics2D.OverlapPointAll(transform.position);
        // Loop through each point
        foreach(var hit in hits)
        {
            // If point overlaps climbable object
            if(hit.tag == "Ladder")
            {
                // Player is overlapping ladder
                isOverLadder = true;
                break; // Exit foreach loop
            }
        }
        // If over climbable object and inputV has been made
        // Is Climbing
        // If Is Climbing
        // Peform logic for climbing
    }

    void Jump()
    {
        // Set velocity's Y to height
        velocity.y = jumpHeight;
    }

    void Hurt()
    {

    }
}
