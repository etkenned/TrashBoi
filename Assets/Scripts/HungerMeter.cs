using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//code for the hunger meter, lives, and respawning
public class HungerMeter : MonoBehaviour
{
  public GameObject life1, life2, life3; // get the life icons in the GUI
  public static bool isDead = false;
  public static float lives = 3f;// keeps track of the number of lives
  public static float hungerLevelMax = 10f; //maxmum hunger level, subject to change
  public static float hungerLevel; //How big the full stomach is for trashboi // this is pubic so multiple scripts can acess it.
    // Start is called before the first frame update
    void Start()
    {
      hungerLevel = hungerLevelMax;
      life1.gameObject.SetActive (true);
      life2.gameObject.SetActive (true);
      life3.gameObject.SetActive (true);
    }

    // Update is called once per frame
    void Update()
    {
        isDead = false; // tells the collectables to stop reseting
        hungerLevel -= Time.deltaTime; // every second the hunger meter loses 1 point
        //hunger level is increased by eating trash, code for that is on the trash objects
        if(hungerLevel < 0)
        {
          Debug.Log("Oh no you ran out of hunger meter and starved!");
          lives -= 1; // lose one life
          isDead = true;
          if(lives == 2)
          {
            life3.gameObject.SetActive (false);// remove the 3rd life
          }
          else if(lives == 1)
          {
            life2.gameObject.SetActive (false);// remove the 2nd life
          }
          if(lives > 0)
          {
            isDead = true; // the player has died so the collectables need to be reset
            transform.position = PlayerMovement.respawnPoint;//respawns
            hungerLevel = hungerLevelMax;
            //Death(); // you lose if th hunger meter goes all the way down.
          }
          else
          {
            life1.gameObject.SetActive (false);// remove the 1st life
            //TESTING --- and game over here
            Debug.Log("You have run out of lives");
            transform.position = PlayerMovement.respawnPoint;//respawns for testing purposes
            hungerLevel = hungerLevelMax;
            //TESTING
          }

        }
    }

    /*
    void LevelReset()
    {

    }
    */
}
