using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public CharacterController2D controller; // references the character controller script from GitHub

    public float runSpeed = 40f; //sets the players movement speed
    public Rigidbody2D rb; //uses the ridgid body of the player
    float horizontalMove = 0f; //stores the direction the player is facing
    float verticalMove = 0f;
    bool jump = false; // is the player jumping curently?
    bool climbing = false;// is the player climning?
    public float distance;// distance of raycast for detecting ladder
    public LayerMask isLadder;//check the ladder layer in unity
    public float climbSpeed;
    // Update is called once per frame
    void Update()
    {
      horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //get input for movement as a number value ### Ex: [left arrow] = -1 and [right arrow] = 1
      if(Input.GetButtonDown("Jump"))
      {
        jump = true;
      }
    }

    void FixedUpdate()// move the player character
    { //fixedDeltaTime ensures that the player speed is always the same across all platforms and systems
      controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump); //gets input for (moveing left and right, crouching, jumping)
      jump = false; //prevents the player from jumping forever

      RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, isLadder); //start position, direction, length

      if(hitInfo.collider != null) //checks if ladder is near
      {
        if(Input.GetKeyDown(KeyCode.UpArrow)) //is the up arrow pressed>
        {
          climbing = true;
        }
      }
      else
      {
        climbing = false; // up arrow is no longer pressed
      }


      if(climbing == true)
      {
        verticalMove = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, verticalMove * climbSpeed);
        rb.gravityScale = 0;//stops the player from falling down while on the ladder
      }
      else
      {
        rb.gravityScale = 3; // resets gravity to normal
      }

    }
}
