using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public Animator animatorEnemy;
    public AudioClip AlertClip;
    public AudioSource AlertSource;
    private bool playedSound = false;
    // Update is called once per frame
    void Start()
    {
      AlertSource.clip = AlertClip;
    }
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
      if(other.tag == "Player")
      {
        //playerLocation = other.transform.position; // sets the players position to a vector object
        if(EnemyController.movingRight == true && other.transform.position.x > transform.position.x && other.transform.position.x < transform.position.x + 5 && PlayerMovement.isHidden == false)
        {

          if(playedSound == false)
          {
            animatorEnemy.SetBool("isAlert", true);
            AlertSource.Play(); // playes the sound
            playedSound = true; // dont play the sound more than once
          }
          EnemyController.seePlayer = true; // if the player is 5 uitys to the right of the enemy while the enemy is facing right and the player is not hidden
        }
        else if(EnemyController.movingRight == false && other.transform.position.x < transform.position.x && other.transform.position.x > transform.position.x - 5 && PlayerMovement.isHidden == false)
        {
          if(playedSound == false)
          {
            animatorEnemy.SetBool("isAlert", true);
            AlertSource.Play(); // playes the sound
            playedSound = true; // dont play the sound more than once
          }
          EnemyController.seePlayer = true; // if the player is 5 uitys to the left of the enemy while the enemy is facing left and the player is not hidden
        }
        else
        {
          animatorEnemy.SetBool("isAlert", false);
          EnemyController.seePlayer = false;
          playedSound = false; // dont play the sound more than once
        }
      }
    }
    void OnTriggerExit2D(Collider2D other)
    {
      animatorEnemy.SetBool("isAlert", false);
      EnemyController.seePlayer = false;
      playedSound = false; // dont play the sound more than once
    }


}
