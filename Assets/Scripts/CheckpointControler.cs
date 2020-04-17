using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointControler : MonoBehaviour
{
  public AudioClip checkPointSound; // chewing sound
  public AudioSource checkPointSource; // where the sound is played from
  public Sprite TrashCanFull; // sprite of unreached checkpoint
  public Sprite TrashCanEmpty;// sprite of reached checkpoint
  private SpriteRenderer checkpointSprite;
  public bool checkpointReached = false; // a bool for if the checkpoint has been reached
    // Start is called before the first frame update
    void Start()
    {
        checkpointSprite = GetComponent <SpriteRenderer> (); //used for changing the art when activated
        checkPointSource.clip = checkPointSound;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.tag == "Player")//if the player collides with the checkpoint
      {
        checkPointSource.Play();
        HungerMeter.hungerLevel = HungerMeter.hungerLevelMax; // fills the hunger level in HungerMeter.cs
        checkpointSprite.sprite = TrashCanEmpty;// swaps sprites for checkpoint
        //Destroy(GetComponent<BoxCollider>());
        checkpointReached = true;
      }
    }
    void OnTriggerExit2D(Collider2D other)
    {
      if(other.tag == "Player") // shows that the player can still get food from the check point
      {
        checkpointSprite.sprite = TrashCanFull;
      }
    }

}
