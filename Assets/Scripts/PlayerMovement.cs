﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public CharacterController2D controller; // references the character controller script from GitHub
    public Animator animator;
    public static float runSpeed = 40f; //sets the players movement speed
    public Rigidbody2D rb; //uses the ridgid body of the player
    float horizontalMove = 0f; //stores the direction the player is facing
    float verticalMove = 0f;
    bool jump = false; // is the player jumping curently?
    public bool climbing = false;// is the player climning?
    public float distance;// distance of raycast for detecting ladder
    public LayerMask isLadder;//check the ladder layer in unity
    public float climbSpeed;
    public Vector3 hiddingLocation; // where to teleport the player
    public Vector3 climbingLock; // used to lock the player to the ladder they are climbing
    public static Vector3 respawnPoint;
    public static Vector3 startingSpawn;
    public static bool isHidden; // the player is hidden and cannot be damaged by an enemy
    public static bool Collected = false;// hve you picked up a power up
    public static string powerUpType;
    private float powerTimerSp;
    private float hurtTimer;
    private float Timer = 0f;
    public static bool disableInput;
    // Update is called once per frame

    void Start()
    {
       respawnPoint = startingSpawn; // sets the respawn point ot the initial spawn
       Collected = false;
       disableInput = false;
    }

    void Update()
    {
      animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); // sets the animator speed variable to the speed of the player so the animator knows when the plaer is moving and can play the run animaition
      Timer += Time.deltaTime;// records how many seconds the level is being run for

      if(powerTimerSp < Timer) // when speed power up runs out
      {
        runSpeed = 40f; // set run speed back to original value
      }
      if(hurtTimer < Timer)
      {
        animator.SetBool("isHurt", false); // the boy is not hurt
        disableInput = false; // give control back to the player
      }

      if(disableInput == false)
      {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //get input for movement as a number value ### Ex: [left arrow] = -1 and [right arrow] = 1
      }


      if(Input.GetButtonDown("Jump")) // the player tries to jump
      {
        animator.SetBool("isJumping", true);
        jump = true;
      }
      if(climbing == true) // is already on the lader so can move freely
      {
        verticalMove = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, verticalMove * climbSpeed);
        if(verticalMove < 0 || verticalMove > 0)
        {
          animator.SetBool("Velocity", true);// tells the animator that the player is moving around the ladder
        }
        else
        {
          animator.SetBool("Velocity", false);
        }
        rb.gravityScale = 0;//stops the player from falling down while on the ladder
      }

      if(Input.GetKeyDown(KeyCode.Q) && Collected == true) // pressing the power up key when you have a power up
      {
        ActivatePower(powerUpType);
        Collected = false;
      }

      if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) // if you move left or right on the ladder you fall off
      {
        climbing = false;
      }

    }


    void FixedUpdate()// move the player character
    { //fixedDeltaTime ensures that the player speed is always the same across all platforms and systems
      controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump); //gets input for (moveing left and right, crouching, jumping)
      jump = false; //prevents the player from jumping forever
      animator.SetBool("isJumping", false); // the player is not jumping anymore
    }



    void OnTriggerStay2D(Collider2D other) // while the player is inside a collider / trigger
    {
      if(other.tag == "Tramp") // when the player jumps on a trampoleen
      {
        rb.AddForce(new Vector2(0f, 1000f)); // boosts the player up with a lot of force
      }
      if(other.tag == "Ladder") // while the player is against a ladder object
      {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) //is the up arrow or W is pressed> attach to ladder
        {
          climbing = true;
          animator.SetBool("isClimbing", true); // tells the animator that the player is climbing
        }
        if(climbing == true)
        {
          climbingLock = transform.position; //sets lock to the players location
          climbingLock.x = other.transform.position.x; // changes the x value of the lock to the ladder's x value
          transform.position = climbingLock; //locks the player to prevent moving side to side on the ladder
        }
        if(climbing == false) // if the player stops climbing while in the collider
        {
          animator.SetBool("isClimbing", false); // tells the animator that the player is no longer climbing
          animator.SetBool("Velocity", false);
          rb.gravityScale = 3; // resets gravity to normal
        }
      }
      if(other.tag == "HiddingSpot") // the player can hids from enemies in boxes with this tag
      {
        if(Input.GetKeyDown(KeyCode.E) && isHidden == false) // activation key is pressed while near the box
        {
          isHidden = true;
          hiddingLocation = other.transform.position; // saves the players current position
          hiddingLocation.z += 5f;
          transform.position = hiddingLocation;
         // move the player behind the scene and disable mvement so you an play the animation
        }
        else if(Input.GetKey(KeyCode.D) && isHidden == true || Input.GetKey(KeyCode.A) && isHidden == true || Input.GetKey(KeyCode.LeftArrow) && isHidden == true || Input.GetKey(KeyCode.RightArrow) && isHidden == true || Input.GetKeyDown(KeyCode.E) && isHidden == true) // get out of the box by moveing
        {
          isHidden = false; // can be damaged now by enemies
          hiddingLocation.z = 0f;
          transform.position = hiddingLocation;
          rb.AddForce(new Vector2(0f, 400f)); // pops the trash boi out of the box
        }
        else if(Input.GetKey(KeyCode.Space) && isHidden == true) // will not give the player a jump boost to pop them out
        {
          isHidden = false; // can be damaged now by enemies
          hiddingLocation.z = 0f;
          transform.position = hiddingLocation;
          rb.AddForce(new Vector2(0f, 40f));
        }

      }

    }



    void OnTriggerExit2D(Collider2D other)
    {
      if(other.tag == "Ladder") // player gets off the ladder
      {
        climbing = false; // prevents the player form climbing forever
        animator.SetBool("isClimbing", false); // tells the animator that the player is no longer climbing
        animator.SetBool("Velocity", false);
        rb.gravityScale = 3; // resets gravity to normal
      }
      if(other.tag == "HiddingSpot")
      {
        isHidden = false;
      }
    }



    void OnTriggerEnter2D(Collider2D other)// if the player collides with another collider
    {
      if(other.tag == "Hazard" && isHidden == false)
      {
        hurtTimer = Timer + .5f; // the player is hurt for 1 second
        animator.SetBool("isHurt", true); // tells the animator the boy got injured
        if(transform.position.x < other.transform.position.x)
        {
          rb.AddForce(new Vector2(-1200f, 400f)); // pushes the player back to the left when they collide with an enemy
        }
        else//
        {
          rb.AddForce(new Vector2(1200f, 400f)); // pushes the player back when they collide with an enemy
        }

        //disableInput = true; // turns off player input for a bit so they cant run around

      }

      if(other.tag == "Checkpoint") // the player collides with a check point
      {
        respawnPoint = other.transform.position;// sets the respawnPoint to the position of the check point
        respawnPoint.z -= 1f;
      }
      if(other.tag == "OutOfBounds")
      {
        transform.position = respawnPoint;
      }
      if(other.tag == "Win Area")
      {
        MenuManager.levelWin = true;
      }
    }


    void ActivatePower(string type)
    {
      if(type == "speed")
      {
        runSpeed += 20f; // boosts the speed of the player
        Debug.Log("run faster");
        powerTimerSp = Timer + 5; // in 5 seconds from now the power up will run out
        MenuManager.colSpeed = false; // tells menu manager to turn off the speed up UI
      }
      else if(type == "jump")
      {

      }
      else if(type == "shield")
      {

      }
      else if(type == "heart")
      {

      }
    }
}
