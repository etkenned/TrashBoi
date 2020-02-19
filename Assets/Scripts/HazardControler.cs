using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardControler : MonoBehaviour
{
    public float damageAmount; // how much hunger damage is dealt when the player collides with the hazard
    public bool isFalling; // is the hazard falling like the potted plant
    public bool isSlowing; // will this slow down the player
    public float speed; //how fast the object falls
    public float distance; // how far the object falls
    public Vector3 startingPositoin; // where the hazard started at
    public Sprite FlowerWhole;
    public Sprite FlowerBroken;
    private SpriteRenderer hazardSprite;

    void Start()
    {

      startingPositoin = transform.position;// sets the point where the flower pot drops
      hazardSprite = GetComponent <SpriteRenderer> ();

    }
    void Update()
    {
      if(isFalling == true)
      {
        transform.Translate (Vector2.down * speed * Time.deltaTime); // moves the hazard down
      }
      if(startingPositoin.y - transform.position.y >= distance)
      {
        hazardSprite.sprite = FlowerBroken; // swaps the sprite of the whole pot for the broken pot
        transform.position = startingPositoin; // moves to the original position
        hazardSprite.sprite = FlowerWhole;
      }
    }

    void OnTriggerEnter2D(Collider2D other) //enters the collider
    {
      if(other.tag == "Player" && isSlowing == true)
      {
        PlayerMovement.Slowed = true;// used for the animator to tell when to use cement walking animaiton 
        PlayerMovement.runSpeed = 10f; // sets the players speed to a slower amount
      }
      if(other.tag == "Player" && PlayerMovement.isHidden == false)
      {
        HungerMeter.hungerLevel -= damageAmount; //subtracts the damage amount from the hunger lever
        if(isFalling == true)
        {
          hazardSprite.sprite = FlowerBroken; // breaks the pot when the player collides with it
        }
      }
    }
    void OnTriggerExit2D(Collider2D other) // leaves the collider
    {
      if(other.tag == "Player" && isSlowing == true) // only affects the hazards that slow the player
      {
        PlayerMovement.Slowed = false;
        PlayerMovement.runSpeed = 40f; // resets the players speed to what it originaly was
      }
    }
}
