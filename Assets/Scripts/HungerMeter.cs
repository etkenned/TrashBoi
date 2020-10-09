using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//code for the hunger meter, lives, and respawning
public class HungerMeter : MonoBehaviour
{
  public AudioClip faintSound;
  public AudioSource faintSource;
  public GameObject life1, life2, life3, happyFace, hungryFace, HM1, HM2, HM3, HM4, HM5, HM6, HM7, HM8, HM9, HM10, HM11, HM12, HM1_Red, HM2_Red, HM3_Red, HM4_Red, HM5_Red, HM6_Red, HM7_Red, HM8_Red, HM9_Red, HM10_Red, HM11_Red, HM12_Red; // get the life icons in the GUI
  public Animator animator; // animator for the player
  public static bool isDead = false;
  public bool pauseMeter;
  public static bool takeDamage = false;
  public static float lives = 3f;// keeps track of the number of lives
  public static float hungerLevelMax = 24f; //maxmum hunger level, subject to change
  public static float hungerLevel; //How big the full stomach is for trashboi // this is pubic so multiple scripts can acess it.

  private bool playerDying;

    // Start is called before the first frame update
    void Start()
    {
      faintSource.clip = faintSound;
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
      playerDying = false;
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
        HM1.SetActive(hungerLevel >= 1 && !takeDamage);
        HM2.SetActive(hungerLevel >= 3 && !takeDamage);
        HM3.SetActive(hungerLevel >= 5 && !takeDamage);
        HM4.SetActive(hungerLevel >= 7 && !takeDamage);
        HM5.SetActive(hungerLevel >= 9 && !takeDamage);
        HM6.SetActive(hungerLevel >= 11 && !takeDamage);
        HM7.SetActive(hungerLevel >= 13 && !takeDamage);
        HM8.SetActive(hungerLevel >= 15 && !takeDamage);
        HM9.SetActive(hungerLevel >= 17 && !takeDamage);
        HM10.SetActive(hungerLevel >= 19 && !takeDamage);
        HM11.SetActive(hungerLevel >= 21 && !takeDamage);
        HM12.SetActive(hungerLevel >= 23 && !takeDamage);

        HM1_Red.SetActive(hungerLevel >= 1);
        HM2_Red.SetActive(hungerLevel >= 3);
        HM3_Red.SetActive(hungerLevel >= 5);
        HM4_Red.SetActive(hungerLevel >= 7);
        HM5_Red.SetActive(hungerLevel >= 9);
        HM6_Red.SetActive(hungerLevel >= 11);
        HM7_Red.SetActive(hungerLevel >= 13);
        HM8_Red.SetActive(hungerLevel >= 15);
        HM9_Red.SetActive(hungerLevel >= 17);
        HM10_Red.SetActive(hungerLevel >= 19);
        HM11_Red.SetActive(hungerLevel >= 21);
        HM12_Red.SetActive(hungerLevel >= 23);

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
        if(hungerLevel < 0 && !playerDying)// runs out of meter
        {
          lives -= 1; // lose one life
          isDead = true; // the player has died so the collectables need to be reset
          if(lives > 0)
          {
                playerDying = true;
                animator.SetTrigger("DeathAnim");
                faintSource.Play();
                StartCoroutine(RespawnPlayer());
          }
          else
          {
                playerDying = true;
                animator.SetTrigger("DeathAnim");
                StartCoroutine(KillPlayer());
          }

        }
    }


    private IEnumerator RespawnPlayer() {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Player Death"));
        //transform.localScale *= 0.66f;
        yield return new WaitForSeconds(4.0f);
        transform.position = PlayerMovement.respawnPoint;//respawns
        hungerLevel = hungerLevelMax;
        animator.SetBool("Dead", true);
        playerDying = false;
        //transform.localScale /= 0.66f;
        if (lives == 2) {
            life3.gameObject.SetActive(false);// remove the 3rd life
        }
        else if (lives == 1) {
            life2.gameObject.SetActive(false);// remove the 2nd life
        }
    }

    private IEnumerator KillPlayer() {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Player Death"));
        transform.localScale *= 0.66f;
        yield return new WaitForSeconds(4.0f);
        life1.gameObject.SetActive(false);// remove the 1st life
        MenuManager.levelLose = true; // tells level changer that the player lost 3 lives
        playerDying = false;
        transform.localScale /= 0.66f;
    }
}
