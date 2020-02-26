using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public Animator animatorEnemy;
    public AudioClip AlertClip;
    public AudioSource AlertSource;
    private bool playedSound = false;
    private Vector3 startingPositionEnemy;// where the enemy spawns at the start of the level
    private bool movingRight = false;
    public float moveDistance; // how far the enemy moves back and forth
    // Update is called once per frame
    void Start()
    {
      startingPositionEnemy = transform.position;
      AlertSource.clip = AlertClip;
    }

    void Update()
    {
      if(transform.position.x >= startingPositionEnemy.x + moveDistance)
      {
        movingRight = false;
      }
      else if(transform.position.x <= startingPositionEnemy.x - moveDistance)
      {
        movingRight = true;
      }
    }

    void OnTriggerStay2D(Collider2D other)
    {
      if(other.tag == "Player")
      {
        //playerLocation = other.transform.position; // sets the players position to a vector object
        if(movingRight == true && other.transform.position.x > transform.position.x && other.transform.position.x < transform.position.x + 5 && PlayerMovement.isHidden == false) // if the player is standing close enough to the right side of the enemy while they are facing the right
        {
          if(playedSound == false)
          {
            animatorEnemy.SetBool("isAlert", true);
            AlertSource.Play(); // playes the sound
            playedSound = true; // dont play the sound more than once
          }
        }
        else if(movingRight == false && other.transform.position.x < transform.position.x && other.transform.position.x > transform.position.x - 5 && PlayerMovement.isHidden == false)
        {
          if(playedSound == false)
          {
            animatorEnemy.SetBool("isAlert", true);
            AlertSource.Play(); // playes the sound
            playedSound = true; // dont play the sound more than once
          }
        }
        else
        {
          animatorEnemy.SetBool("isAlert", false);
          playedSound = false; // dont play the sound more than once
        }
      }
    }
    void OnTriggerExit2D(Collider2D other)
    {
      animatorEnemy.SetBool("isAlert", false);
      playedSound = false; // dont play the sound more than once
    }


}
