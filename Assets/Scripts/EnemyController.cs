using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  public float damageAmount;// how much damage the ememy will deal to the hunger meter
    // Start is called before the first frame update
  private SpriteRenderer enemySprite;
  public float speed;
  public static bool movingRight = false;
  private Vector3 startingPositionEnemy;// where the enemy spawns at the start of the level
  public float moveDistance; // how far the enemy moves back and forth
  public static bool seePlayer; // the enemy can see the player, the enemy will stop moving if they can see the player
    void Start()
    {
      enemySprite = GetComponent <SpriteRenderer> ();
      startingPositionEnemy = transform.position;
      seePlayer = false;
    }
    // Update is called once per frame
    void Update()
    {

      if(movingRight == true && seePlayer == false)
      {
        enemySprite.flipX = true; //flips the sprite to the right
        transform.Translate (Vector2.right * speed * Time.deltaTime); //moves to the right
      }
      else if(movingRight == false && seePlayer == false)
      {
        enemySprite.flipX = false; // flips the sprite to the left
        transform.Translate (-Vector2.right * speed * Time.deltaTime); // moves to the left
      }
      if(transform.position.x >= startingPositionEnemy.x + moveDistance)
      {
        movingRight = false;
      }
      else if(transform.position.x <= startingPositionEnemy.x - moveDistance)
      {
        movingRight = true;
      }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.tag == "Player" && PlayerMovement.isHidden == false)
      {
        HungerMeter.hungerLevel -= damageAmount; //subtracts the damage amount from the hunger lever
      }
    }
}
