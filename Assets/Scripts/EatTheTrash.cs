using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EatTheTrash : MonoBehaviour
{
  public AudioClip eatingSound; // chewing sound
  public AudioSource trashSource; // where the sound is played from
  public float trashValue;
  private Vector3 startingPosition;
  private Vector3 hiddenPosition; //used for hiding the trash after it has been eaten
    // Start is called before the first frame update
    void Start()
    {
      startingPosition = transform.position; // where the trash is intially
      hiddenPosition = startingPosition; // where to hide the trash when it is collected
      hiddenPosition.y -= 30f; // yeet that trash into the center of the earth
      trashSource.clip = eatingSound;
    }

    // Update is called once per frame
    void Update()
    {
      if(HungerMeter.isDead == true)
      {
        ResetTrash();
      }
    }

    void ResetTrash()
    {
      transform.position = startingPosition; // restarts the level so the trash is now back at its original position
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.tag == "Player")
      {
        transform.position = hiddenPosition;
        trashSource.Play();// plays the sound of the trash being eaten
        if(HungerMeter.hungerLevel + trashValue > HungerMeter.hungerLevelMax) // if you eat more trash than you have room in your belly/ hunger meter, you do not go over the maximum amount
        {
          HungerMeter.hungerLevel = HungerMeter.hungerLevelMax; // sets the hunger meter to full and not over
        }
        else
        {
          HungerMeter.hungerLevel += trashValue; // adds a preset number of points to the hunger level in HungerMeter.cs
        }
      }
    }
}
