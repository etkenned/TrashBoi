using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//code for the hunger meter, lives, and respawning
public class HungerMeter : MonoBehaviour
{
  public GameObject life1, life2, life3, happyFace, hungryFace, HM1, HM2, HM3, HM4, HM5, HM6, HM7, HM8, HM9, HM10, HM11, HM12, HM1_Red, HM2_Red, HM3_Red, HM4_Red, HM5_Red, HM6_Red, HM7_Red, HM8_Red, HM9_Red, HM10_Red, HM11_Red, HM12_Red; // get the life icons in the GUI
  public Animator animator; // animator for the player
  public static bool isDead = false;
  public bool pauseMeter;
  public static bool takeDamage = false;
  public static float lives = 3f;// keeps track of the number of lives
  public static float hungerLevelMax = 24f; //maxmum hunger level, subject to change
  public static float hungerLevel; //How big the full stomach is for trashboi // this is pubic so multiple scripts can acess it.

    // Start is called before the first frame update
    void Start()
    {
      lives = 3; // gives the player 3 lives at the start of each scene incase something doesnt reset them
      hungerLevel = hungerLevelMax;
      life1.gameObject.SetActive (true);
      life2.gameObject.SetActive (true);
      life3.gameObject.SetActive (true);
      happyFace.gameObject.SetActive (true);
      hungryFace.gameObject.SetActive (false);
      HM1.gameObject.SetActive (true);
      HM2.gameObject.SetActive (true);
      HM3.gameObject.SetActive (true);
      HM4.gameObject.SetActive (true);
      HM5.gameObject.SetActive (true);
      HM6.gameObject.SetActive (true);
      HM7.gameObject.SetActive (true);
      HM8.gameObject.SetActive (true);
      HM9.gameObject.SetActive (true);
      HM10.gameObject.SetActive (true);
      HM11.gameObject.SetActive (true);
      HM12.gameObject.SetActive (true);
      //pauseMeter = false;
    }

    // Update is called once per frame
    void Update()
    {
        isDead = false; // tells the collectables to stop reseting
        animator.SetBool("Dead", false);
        if(pauseMeter == false)
        {
          hungerLevel -= Time.deltaTime; // every second the hunger meter loses 1 point
        }

        //hunger level is increased by eating trash, code for that is on the trash objects
        if(lives == 3)// give the player back their lives on a level reset
        {
          life1.gameObject.SetActive (true);
          life2.gameObject.SetActive (true);
          life3.gameObject.SetActive (true);
        }

        //visual representation of hunger meter
        if(takeDamage == true)
        {
          HM1.gameObject.SetActive (false);
          HM2.gameObject.SetActive (false);
          HM3.gameObject.SetActive (false);
          HM4.gameObject.SetActive (false);
          HM5.gameObject.SetActive (false);
          HM6.gameObject.SetActive (false);
          HM7.gameObject.SetActive (false);
          HM8.gameObject.SetActive (false);
          HM9.gameObject.SetActive (false);
          HM10.gameObject.SetActive (false);
          HM11.gameObject.SetActive (false);
          HM12.gameObject.SetActive (false);

        }
        else if(hungerLevel >= 23)
        {
          HM1.gameObject.SetActive (true);
          HM2.gameObject.SetActive (true);
          HM3.gameObject.SetActive (true);
          HM4.gameObject.SetActive (true);
          HM5.gameObject.SetActive (true);
          HM6.gameObject.SetActive (true);
          HM7.gameObject.SetActive (true);
          HM8.gameObject.SetActive (true);
          HM9.gameObject.SetActive (true);
          HM10.gameObject.SetActive (true);
          HM11.gameObject.SetActive (true);
          HM12.gameObject.SetActive (true);

          HM1_Red.gameObject.SetActive (true);
          HM2_Red.gameObject.SetActive (true);
          HM3_Red.gameObject.SetActive (true);
          HM4_Red.gameObject.SetActive (true);
          HM5_Red.gameObject.SetActive (true);
          HM6_Red.gameObject.SetActive (true);
          HM7_Red.gameObject.SetActive (true);
          HM8_Red.gameObject.SetActive (true);
          HM9_Red.gameObject.SetActive (true);
          HM10_Red.gameObject.SetActive (true);
          HM11_Red.gameObject.SetActive (true);
          HM12_Red.gameObject.SetActive (true);
        }
        else if(hungerLevel >= 21 && hungerLevel < 23)
        {
          HM1.gameObject.SetActive (true);
          HM2.gameObject.SetActive (true);
          HM3.gameObject.SetActive (true);
          HM4.gameObject.SetActive (true);
          HM5.gameObject.SetActive (true);
          HM6.gameObject.SetActive (true);
          HM7.gameObject.SetActive (true);
          HM8.gameObject.SetActive (true);
          HM9.gameObject.SetActive (true);
          HM10.gameObject.SetActive (true);
          HM11.gameObject.SetActive (true);
          HM12.gameObject.SetActive (false);

          HM1_Red.gameObject.SetActive (true);
          HM2_Red.gameObject.SetActive (true);
          HM3_Red.gameObject.SetActive (true);
          HM4_Red.gameObject.SetActive (true);
          HM5_Red.gameObject.SetActive (true);
          HM6_Red.gameObject.SetActive (true);
          HM7_Red.gameObject.SetActive (true);
          HM8_Red.gameObject.SetActive (true);
          HM9_Red.gameObject.SetActive (true);
          HM10_Red.gameObject.SetActive (true);
          HM11_Red.gameObject.SetActive (true);
          HM12_Red.gameObject.SetActive (false);
        }
        else if(hungerLevel >= 19 && hungerLevel < 21)
        {
          HM1.gameObject.SetActive (true);
          HM2.gameObject.SetActive (true);
          HM3.gameObject.SetActive (true);
          HM4.gameObject.SetActive (true);
          HM5.gameObject.SetActive (true);
          HM6.gameObject.SetActive (true);
          HM7.gameObject.SetActive (true);
          HM8.gameObject.SetActive (true);
          HM9.gameObject.SetActive (true);
          HM10.gameObject.SetActive (true);
          HM11.gameObject.SetActive (false);
          HM12.gameObject.SetActive (false);

          HM1_Red.gameObject.SetActive (true);
          HM2_Red.gameObject.SetActive (true);
          HM3_Red.gameObject.SetActive (true);
          HM4_Red.gameObject.SetActive (true);
          HM5_Red.gameObject.SetActive (true);
          HM6_Red.gameObject.SetActive (true);
          HM7_Red.gameObject.SetActive (true);
          HM8_Red.gameObject.SetActive (true);
          HM9_Red.gameObject.SetActive (true);
          HM10_Red.gameObject.SetActive (true);
          HM11_Red.gameObject.SetActive (false);
          HM12_Red.gameObject.SetActive (false);
        }
        else if(hungerLevel >= 17 && hungerLevel < 19)
        {
          HM1.gameObject.SetActive (true);
          HM2.gameObject.SetActive (true);
          HM3.gameObject.SetActive (true);
          HM4.gameObject.SetActive (true);
          HM5.gameObject.SetActive (true);
          HM6.gameObject.SetActive (true);
          HM7.gameObject.SetActive (true);
          HM8.gameObject.SetActive (true);
          HM9.gameObject.SetActive (true);
          HM10.gameObject.SetActive (false);
          HM11.gameObject.SetActive (false);
          HM12.gameObject.SetActive (false);

          HM1_Red.gameObject.SetActive (true);
          HM2_Red.gameObject.SetActive (true);
          HM3_Red.gameObject.SetActive (true);
          HM4_Red.gameObject.SetActive (true);
          HM5_Red.gameObject.SetActive (true);
          HM6_Red.gameObject.SetActive (true);
          HM7_Red.gameObject.SetActive (true);
          HM8_Red.gameObject.SetActive (true);
          HM9_Red.gameObject.SetActive (true);
          HM10_Red.gameObject.SetActive (false);
          HM11_Red.gameObject.SetActive (false);
          HM12_Red.gameObject.SetActive (false);
        }
        else if(hungerLevel >= 15 && hungerLevel < 17)
        {
          HM1.gameObject.SetActive (true);
          HM2.gameObject.SetActive (true);
          HM3.gameObject.SetActive (true);
          HM4.gameObject.SetActive (true);
          HM5.gameObject.SetActive (true);
          HM6.gameObject.SetActive (true);
          HM7.gameObject.SetActive (true);
          HM8.gameObject.SetActive (true);
          HM9.gameObject.SetActive (false);
          HM10.gameObject.SetActive (false);
          HM11.gameObject.SetActive (false);
          HM12.gameObject.SetActive (false);

          HM1_Red.gameObject.SetActive (true);
          HM2_Red.gameObject.SetActive (true);
          HM3_Red.gameObject.SetActive (true);
          HM4_Red.gameObject.SetActive (true);
          HM5_Red.gameObject.SetActive (true);
          HM6_Red.gameObject.SetActive (true);
          HM7_Red.gameObject.SetActive (true);
          HM8_Red.gameObject.SetActive (true);
          HM9_Red.gameObject.SetActive (false);
          HM10_Red.gameObject.SetActive (false);
          HM11_Red.gameObject.SetActive (false);
          HM12_Red.gameObject.SetActive (false);
        }
        else if(hungerLevel >= 13 && hungerLevel < 15)
        {
          HM1.gameObject.SetActive (true);
          HM2.gameObject.SetActive (true);
          HM3.gameObject.SetActive (true);
          HM4.gameObject.SetActive (true);
          HM5.gameObject.SetActive (true);
          HM6.gameObject.SetActive (true);
          HM7.gameObject.SetActive (true);
          HM8.gameObject.SetActive (false);
          HM9.gameObject.SetActive (false);
          HM10.gameObject.SetActive (false);
          HM11.gameObject.SetActive (false);
          HM12.gameObject.SetActive (false);

          HM1_Red.gameObject.SetActive (true);
          HM2_Red.gameObject.SetActive (true);
          HM3_Red.gameObject.SetActive (true);
          HM4_Red.gameObject.SetActive (true);
          HM5_Red.gameObject.SetActive (true);
          HM6_Red.gameObject.SetActive (true);
          HM7_Red.gameObject.SetActive (true);
          HM8_Red.gameObject.SetActive (false);
          HM9_Red.gameObject.SetActive (false);
          HM10_Red.gameObject.SetActive (false);
          HM11_Red.gameObject.SetActive (false);
          HM12_Red.gameObject.SetActive (false);
        }
        else if(hungerLevel >= 11 && hungerLevel < 13)
        {
          HM1.gameObject.SetActive (true);
          HM2.gameObject.SetActive (true);
          HM3.gameObject.SetActive (true);
          HM4.gameObject.SetActive (true);
          HM5.gameObject.SetActive (true);
          HM6.gameObject.SetActive (true);
          HM7.gameObject.SetActive (false);
          HM8.gameObject.SetActive (false);
          HM9.gameObject.SetActive (false);
          HM10.gameObject.SetActive (false);
          HM11.gameObject.SetActive (false);
          HM12.gameObject.SetActive (false);

          HM1_Red.gameObject.SetActive (true);
          HM2_Red.gameObject.SetActive (true);
          HM3_Red.gameObject.SetActive (true);
          HM4_Red.gameObject.SetActive (true);
          HM5_Red.gameObject.SetActive (true);
          HM6_Red.gameObject.SetActive (true);
          HM7_Red.gameObject.SetActive (false);
          HM8_Red.gameObject.SetActive (false);
          HM9_Red.gameObject.SetActive (false);
          HM10_Red.gameObject.SetActive (false);
          HM11_Red.gameObject.SetActive (false);
          HM12_Red.gameObject.SetActive (false);
        }
        else if(hungerLevel >= 9 && hungerLevel < 11)
        {
          HM1.gameObject.SetActive (true);
          HM2.gameObject.SetActive (true);
          HM3.gameObject.SetActive (true);
          HM4.gameObject.SetActive (true);
          HM5.gameObject.SetActive (true);
          HM6.gameObject.SetActive (false);
          HM7.gameObject.SetActive (false);
          HM8.gameObject.SetActive (false);
          HM9.gameObject.SetActive (false);
          HM10.gameObject.SetActive (false);
          HM11.gameObject.SetActive (false);
          HM12.gameObject.SetActive (false);

          HM1_Red.gameObject.SetActive (true);
          HM2_Red.gameObject.SetActive (true);
          HM3_Red.gameObject.SetActive (true);
          HM4_Red.gameObject.SetActive (true);
          HM5_Red.gameObject.SetActive (true);
          HM6_Red.gameObject.SetActive (false);
          HM7_Red.gameObject.SetActive (false);
          HM8_Red.gameObject.SetActive (false);
          HM9_Red.gameObject.SetActive (false);
          HM10_Red.gameObject.SetActive (false);
          HM11_Red.gameObject.SetActive (false);
          HM12_Red.gameObject.SetActive (false);
        }
        else if(hungerLevel >= 7 && hungerLevel < 9)
        {
          HM1.gameObject.SetActive (true);
          HM2.gameObject.SetActive (true);
          HM3.gameObject.SetActive (true);
          HM4.gameObject.SetActive (true);
          HM5.gameObject.SetActive (false);
          HM6.gameObject.SetActive (false);
          HM7.gameObject.SetActive (false);
          HM8.gameObject.SetActive (false);
          HM9.gameObject.SetActive (false);
          HM10.gameObject.SetActive (false);
          HM11.gameObject.SetActive (false);
          HM12.gameObject.SetActive (false);

          HM1_Red.gameObject.SetActive (true);
          HM2_Red.gameObject.SetActive (true);
          HM3_Red.gameObject.SetActive (true);
          HM4_Red.gameObject.SetActive (true);
          HM5_Red.gameObject.SetActive (false);
          HM6_Red.gameObject.SetActive (false);
          HM7_Red.gameObject.SetActive (false);
          HM8_Red.gameObject.SetActive (false);
          HM9_Red.gameObject.SetActive (false);
          HM10_Red.gameObject.SetActive (false);
          HM11_Red.gameObject.SetActive (false);
          HM12_Red.gameObject.SetActive (false);
        }
        else if(hungerLevel >= 5 && hungerLevel < 7)
        {
          HM1.gameObject.SetActive (true);
          HM2.gameObject.SetActive (true);
          HM3.gameObject.SetActive (true);
          HM4.gameObject.SetActive (false);
          HM5.gameObject.SetActive (false);
          HM6.gameObject.SetActive (false);
          HM7.gameObject.SetActive (false);
          HM8.gameObject.SetActive (false);
          HM9.gameObject.SetActive (false);
          HM10.gameObject.SetActive (false);
          HM11.gameObject.SetActive (false);
          HM12.gameObject.SetActive (false);

          HM1_Red.gameObject.SetActive (true);
          HM2_Red.gameObject.SetActive (true);
          HM3_Red.gameObject.SetActive (true);
          HM4_Red.gameObject.SetActive (false);
          HM5_Red.gameObject.SetActive (false);
          HM6_Red.gameObject.SetActive (false);
          HM7_Red.gameObject.SetActive (false);
          HM8_Red.gameObject.SetActive (false);
          HM9_Red.gameObject.SetActive (false);
          HM10_Red.gameObject.SetActive (false);
          HM11_Red.gameObject.SetActive (false);
          HM12_Red.gameObject.SetActive (false);
        }
        else if(hungerLevel >= 3 && hungerLevel < 5)
        {
          HM1.gameObject.SetActive (true);
          HM2.gameObject.SetActive (true);
          HM3.gameObject.SetActive (false);
          HM4.gameObject.SetActive (false);
          HM5.gameObject.SetActive (false);
          HM6.gameObject.SetActive (false);
          HM7.gameObject.SetActive (false);
          HM8.gameObject.SetActive (false);
          HM9.gameObject.SetActive (false);
          HM10.gameObject.SetActive (false);
          HM11.gameObject.SetActive (false);
          HM12.gameObject.SetActive (false);

          HM1_Red.gameObject.SetActive (true);
          HM2_Red.gameObject.SetActive (true);
          HM3_Red.gameObject.SetActive (false);
          HM4_Red.gameObject.SetActive (false);
          HM5_Red.gameObject.SetActive (false);
          HM6_Red.gameObject.SetActive (false);
          HM7_Red.gameObject.SetActive (false);
          HM8_Red.gameObject.SetActive (false);
          HM9_Red.gameObject.SetActive (false);
          HM10_Red.gameObject.SetActive (false);
          HM11_Red.gameObject.SetActive (false);
          HM12_Red.gameObject.SetActive (false);
        }
        else if(hungerLevel >= 1 && hungerLevel < 3)
        {
          HM1.gameObject.SetActive (true);
          HM2.gameObject.SetActive (false);
          HM3.gameObject.SetActive (false);
          HM4.gameObject.SetActive (false);
          HM5.gameObject.SetActive (false);
          HM6.gameObject.SetActive (false);
          HM7.gameObject.SetActive (false);
          HM8.gameObject.SetActive (false);
          HM9.gameObject.SetActive (false);
          HM10.gameObject.SetActive (false);
          HM11.gameObject.SetActive (false);
          HM12.gameObject.SetActive (false);

          HM1_Red.gameObject.SetActive (true);
          HM2_Red.gameObject.SetActive (false);
          HM3_Red.gameObject.SetActive (false);
          HM4_Red.gameObject.SetActive (false);
          HM5_Red.gameObject.SetActive (false);
          HM6_Red.gameObject.SetActive (false);
          HM7_Red.gameObject.SetActive (false);
          HM8_Red.gameObject.SetActive (false);
          HM9_Red.gameObject.SetActive (false);
          HM10_Red.gameObject.SetActive (false);
          HM11_Red.gameObject.SetActive (false);
          HM12_Red.gameObject.SetActive (false);
        }
        else if(hungerLevel < 1)
        {
          HM1.gameObject.SetActive (false);
          HM2.gameObject.SetActive (false);
          HM3.gameObject.SetActive (false);
          HM4.gameObject.SetActive (false);
          HM5.gameObject.SetActive (false);
          HM6.gameObject.SetActive (false);
          HM7.gameObject.SetActive (false);
          HM8.gameObject.SetActive (false);
          HM9.gameObject.SetActive (false);
          HM10.gameObject.SetActive (false);
          HM11.gameObject.SetActive (false);
          HM12.gameObject.SetActive (false);

          HM1_Red.gameObject.SetActive (false);
          HM2_Red.gameObject.SetActive (false);
          HM3_Red.gameObject.SetActive (false);
          HM4_Red.gameObject.SetActive (false);
          HM5_Red.gameObject.SetActive (false);
          HM6_Red.gameObject.SetActive (false);
          HM7_Red.gameObject.SetActive (false);
          HM8_Red.gameObject.SetActive (false);
          HM9_Red.gameObject.SetActive (false);
          HM10_Red.gameObject.SetActive (false);
          HM11_Red.gameObject.SetActive (false);
          HM12_Red.gameObject.SetActive (false);
        }

        if(hungerLevel > (hungerLevelMax / 2))// change the face icon
        {
          happyFace.gameObject.SetActive (true);
          hungryFace.gameObject.SetActive (false);
        }
        else if(hungerLevel <= (hungerLevelMax / 2))//change the face icon
        {
          happyFace.gameObject.SetActive (false);
          hungryFace.gameObject.SetActive (true);
        }
        if(hungerLevel < 0)// runs out of meter
        {
          lives -= 1; // lose one life
          isDead = true; // the player has died so the collectables need to be reset
          animator.SetBool("Dead", true);
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
            //isDead = true; // the player has died so the collectables need to be reset
            transform.position = PlayerMovement.respawnPoint;//respawns
            hungerLevel = hungerLevelMax;
          }
          else
          {
            life1.gameObject.SetActive (false);// remove the 1st life
            MenuManager.levelLose = true; // tells level changer that the player lost 3 lives
          }

        }
    }

}
