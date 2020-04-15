using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPot : MonoBehaviour
{
    public Animator animator; // animator for the flower
    public float damageAmount; // how much hunger damage is dealt when the player collides with the hazard
    public float speed; //how fast the object falls
    public float distance; // how far the object fall
    private float Timer = 0f;
    private float waitTimer = 0f;
    public Vector3 startingPosition; // where the hazard started at
    private bool falling = true;
    private bool landed = false; //used so the code doesnt loop
    private BoxCollider2D flowerCollider;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;// sets the point where the flower pot drops
        flowerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
      Timer += Time.deltaTime;

      if(falling)
      {
        transform.Translate (Vector2.down * speed * Time.deltaTime); // moves the flower down
      }
      if(startingPosition.y - transform.position.y >= distance) // flower hits the ground
      {
        if(!landed) // if this is the flower's initial landing on the ground
        {
          animator.SetTrigger("Breaking");//trigger break animation
          falling = false; // stops the flower from going through the ground
          waitTimer = Timer + 1.0f;
          landed = true;
          flowerCollider.enabled = false;
        }
        if(waitTimer < Timer) // reset the pot
        {
          transform.position = startingPosition; // moves to the original position
          animator.SetTrigger("Reset");
          falling = true;
          landed = false;
          flowerCollider.enabled = true;
        }

      }

    }

    void OnTriggerEnter2D(Collider2D other) //enters the collider
    {
      if(other.tag == "Player" && PlayerMovement.isHidden == false)
      {
        HungerMeter.hungerLevel -= damageAmount; //subtracts the damage amount from the hunger lever
        animator.SetTrigger("Breaking");
      }
    }
}
