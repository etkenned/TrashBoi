using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerMeter : MonoBehaviour
{

  public static float lives = 3f;
  public static float hungerLevel = 10f; //How big the full stomach is for trashboi // this is pubic so multiple scripts can acess it.
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hungerLevel -= Time.deltaTime; // every second the hunger meter loses 1 point
        //hunger level is increased by eating trash, code for that is on the trash objects
        if(hungerLevel < 0)
        {
          Debug.Log("Oh no you ran out of hunger meter and starved!");
          lives -= 1; // lose one life

          transform.position = PlayerMovement.respawnPoint;//respawns
          hungerLevel = 10f;
          //Death(); // you lose if th hunger meter goes all the way down.
        }
    }

    /*
    void Death()
    {

    }
    */
}
