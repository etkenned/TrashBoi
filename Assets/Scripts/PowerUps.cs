using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
  public bool isSpeed; // is this the speed boost power up?
  public bool isJump; // is this the jump boost ?
  public bool isShield; // is this the protectve cone?
  public bool isHeart; // is this a one up?

  private Vector3 startingPosition;
  private Vector3 hiddenPosition; //used for hiding the trash after it has been eaten
    // Start is called before the first frame update
    void Start()
    {
      startingPosition = transform.position; // where the power up is intially
      hiddenPosition = startingPosition; // where to hide the power up when it is collected
      hiddenPosition.y -= 30f;
    }

    // Update is called once per frame
    void Update()
    {
      if(HungerMeter.isDead == true) // reset on player death
      {
        ResetPowerUp();
      }
    }

    void ResetPowerUp()
    {
      transform.position = startingPosition; // restarts the level so the power up is now back at its original position
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.tag == "Player" && PlayerMovement.Collected == false) // if the player touches the power up and does not currently have a power up then they can pick up a new one
      {
        transform.position = hiddenPosition; //hides the power up
        PlayerMovement.Collected = true; // tells the player that it has been collected
        if(isSpeed == true)
        {
          PlayerMovement.powerUpType = "speed"; //tells the player what kind of power up it was
           MenuManager.colSpeed = true;// displays on the UI that you picked it up

        }
        else if(isJump == true)
        {
          PlayerMovement.powerUpType = "jump";
        }
        else if(isShield == true)
        {
          PlayerMovement.powerUpType = "shield";
        }
        else if(isHeart == true)
        {
          PlayerMovement.powerUpType = "heart";
        }
      }
    }

}
