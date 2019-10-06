using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointControler : MonoBehaviour
{
  public Sprite TrashCanFull; // sprite of unreached checkpoint
  public Sprite TrashCanEmpty;// sprite of reached checkpoint
  private SpriteRenderer checkpointSprite;
  public bool checkpointReached = false; // a bool for if the checkpoint has been reached
    // Start is called before the first frame update
    void Start()
    {
        checkpointSprite = GetComponent <SpriteRenderer> ();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.tag == "Player")//if the player collides with the checkpoint
      {
        HungerMeter.hungerLevel = 10f; // fills the hunger level in HungerMeter.cs
        Debug.Log("Yum, you ate some garbage from the can");
        checkpointSprite.sprite = TrashCanEmpty;// swaps sprites for checkpoint
        //Destroy(GetComponent<BoxCollider>());
        checkpointReached = true;
      }
    }

}
