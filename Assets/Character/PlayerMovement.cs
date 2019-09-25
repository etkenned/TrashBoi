using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public CharacterController2D controller; // references the character controller script from GitHub

    public float runSpeed = 40f; //sets the players movement speed
    float horizontalMove = 0f; //stores the direction the player is facing
    bool jump = false; // is the player jumping curently?
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

    }
}
