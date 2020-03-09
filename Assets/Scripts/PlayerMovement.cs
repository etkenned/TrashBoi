using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public CharacterController2D controller; // references the character controller script from GitHub
    public Animator animator; // animator for the player
    public static float runSpeed = 40f; //sets the players movement speed
    public Rigidbody2D rb; //uses the ridgid body of the player
    float horizontalMove = 0f; //stores the direction the player is facing
    float verticalMove = 0f;
    bool jump = false; // is the player jumping curently?
    public bool climbing = false;// is the player climning?
    public float distance;// distance of raycast for detecting ladder
    public LayerMask isLadder;//check the ladder layer in unity
    public float climbSpeed; // how fast the player can climb
    public Vector2 hiddingLocation; // where to teleport the player
    public Vector3 climbingLock; // used to lock the player to the ladder they are climbing
    public static Vector3 respawnPoint;
    public static Vector3 startingSpawn;
    public static bool isHidden; // the player is hidden and cannot be damaged by an enemy
    public static bool Collected = false;// hve you picked up a power up
    public static string powerUpType; //which power-up got picked up
    private float powerTimerSp; // how long the speed power-up lasts
    private float hurtTimer; // how long the player is "hurt" for
    private float Timer = 0f;
    public static bool disableInput; // used for taking away a player's ability to move
    public AudioClip scaredSound; // scream from the trash boy
    public AudioSource scaredSource; // where the sound is played from
    public static bool Slowed;

    private CharacterController2D cc2d;
    // Update is called once per frame
    void Start()
    {
        cc2d = GetComponent<CharacterController2D>();
       scaredSource.clip = scaredSound; // sets the clip to play
       respawnPoint = startingSpawn; // sets the respawn point ot the initial spawn
       Collected = false;
       disableInput = false;
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); // sets the animator speed variable to the speed of the player so the animator knows when the plaer is moving and can play the run animaition

      if(Mathf.Abs(horizontalMove) >= .01f && CharacterController2D.m_Grounded == true) // is the player walking along the ground?
      {
        //use this for playing a noise for player walking
      }

      Timer += Time.deltaTime;// records how many seconds the level is being run for

      if(Slowed)
      {
        animator.SetBool("InCement", true);
      }
      else
      {
        animator.SetBool("InCement", false);
      }

      if(powerTimerSp < Timer) // when speed power up runs out
      {
        runSpeed = 40f; // set run speed back to original value
      }
      if(hurtTimer < Timer)
      {
        animator.SetBool("isHurt", false); // the boy is not hurt
        HungerMeter.takeDamage = false; // used for hunger meter changing color
        disableInput = false; // give control back to the player
        cc2d.airControl = true;
      }

      if(!MenuManager.isPaused)
      {
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
          if (Input.GetButtonDown("Jump")) // the player tries to jump off of the ladder
          {
            rb.gravityScale = 3; //Resets gravity to normal
            climbing = false;
            animator.SetBool("isJumping", true);
            controller.Jump();
          }
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

    }


    void FixedUpdate()// move the player character
    { //fixedDeltaTime ensures that the player speed is always the same across all platforms and systems
      if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Powerup") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Dumpster Finale")) {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump); //gets input for (moveing left and right, crouching, jumping)
      } else {
        controller.Move(0f, false, false);
      }
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
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) //is the up arrow or W is pressed> attach to ladder
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
        if(Input.GetKey(KeyCode.E) && isHidden == false && Mathf.Abs(horizontalMove) <= .01) // activation key is pressed while near the box, cannot enter wile moveing
        {
          isHidden = true;
          rb.gravityScale = 0;// allows the player to me moved to the right spot above the box
          hiddingLocation = other.transform.position; // saves the players current position
          animator.SetBool("enterBox", true);// tells animator to play enter box animaition
          hiddingLocation.y += .15f; // adjusts for the box's height
          transform.position = hiddingLocation;
          rb.velocity = new Vector2(0f, 0f);
         // move the player behind the scene and disable mvement so you an play the animation
        }
        else if(Input.GetKey(KeyCode.D) && isHidden == true || Input.GetKey(KeyCode.A) && isHidden == true || Input.GetKey(KeyCode.LeftArrow) && isHidden == true || Input.GetKey(KeyCode.RightArrow) && isHidden == true) // get out of the box by moveing
        {
          animator.SetBool("enterBox", false);// tells animator to play exit box animaition
          isHidden = false; // can be damaged now by enemies
          rb.gravityScale = 3;// returns gravity to normal
          //hiddingLocation.z = 0f;
          transform.position = hiddingLocation;
          //rb.AddForce(new Vector2(0f, 400f)); // pops the trash boi out of the box
        }
        else if(Input.GetKey(KeyCode.Space) && isHidden == true) // will not give the player a jump boost to pop them out
        {
          animator.SetBool("enterBox", false);// tells animator to play exit box animaition
          isHidden = false; // can be damaged now by enemies
          rb.gravityScale = 3;// returns gravity to normal
          //hiddingLocation.z = 0f;
          transform.position = hiddingLocation;
          //rb.AddForce(new Vector2(0f, 40f));
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
        animator.SetBool("enterBox", false);// tells animator to play exit box animaition
        isHidden = false;
        rb.gravityScale = 3;// returns gravity to normal

      }
    }



    void OnTriggerEnter2D(Collider2D other)// if the player collides with another collider
    {
      if(other.tag == "Hazard" && isHidden == false)
      {
        HungerMeter.takeDamage = true;
        hurtTimer = Timer + .5f; // the player is hurt for 1 second
        animator.SetBool("isHurt", true); // tells the animator the boy got injured
        //Raising position just a little bit to stop grounded physics from messing with the forces
        transform.position = transform.position + new Vector3(0, 0.1f, 0);
        cc2d.airControl = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        scaredSource.Play(); // plays a sound for getting hurt
        if(transform.position.x < other.transform.position.x)
        {
          rb.AddForce(new Vector2(-300f, 300f)); // pushes the player back to the left when they collide with an enemy
        }
        else//
        {
          rb.AddForce(new Vector2(300f, 300f)); // pushes the player back when they collide with an enemy
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
        rb.isKinematic = true;
        transform.localScale *= 2.0f;
        transform.position = new Vector2(other.transform.position.x - 2.5f, other.transform.position.y + 0.2f);
        StartCoroutine(WinLevel());
      }
    }


    void ActivatePower(string type)
    {
      animator.SetTrigger("Powerup");
      if (type == "speed")
      {
        runSpeed += 20f; // boosts the speed of the player
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

    private IEnumerator WinLevel() {
        animator.SetTrigger("Dumpster");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        MenuManager.levelWin = true;
    }
}
