using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

  public GameObject winMenu, loseMenu, pauseMenu, player;
  public GameObject speedText, speedArt, jumpText, jumpArt, shieldText, shieldArt, heartText, heartArt; // UI elements for collecting power ups
  public static bool levelWin = false;
  public static bool levelLose = false;
  public static bool colSpeed = false; // was the speed power up collected?
  public static bool colJump = false;
  public static bool colShield = false;
  public static bool colHeart = false;
  public static bool isPaused = false;
  public static bool tipOpen = false;
  public Text timerText_pause;
  public Text timerText_end;
  public float levelTimeSec = 0f;
  public float levelTimeMin = 0f;// used to keep track of how long the player is taking to complete the level
    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 1; // makes sure time is moving
      levelWin = false;
      levelLose = false;
      levelTimeMin = 0f;
      levelTimeSec = 0f;
      winMenu.gameObject.SetActive (false);// at the start of the level the win screen is turned off
      loseMenu.gameObject.SetActive (false);// at the start of the level the lose creen is turned off
      pauseMenu.gameObject.SetActive (false);// at the start of the level the pause screen is turned off
      TurnOffPowerUps();
      isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
      levelTimeSec += Time.deltaTime; // records how long you are playing
      if(HungerMeter.isDead == true)// if the player loses a life, they lose the power up they were holding
      {
        TurnOffPowerUps();
      }
      if(levelTimeSec >= 60) // every 60 seconds marks a minute
      {
        levelTimeMin += 1;
        levelTimeSec = 0;
      }
      timerText_pause.text = levelTimeMin + ":" + levelTimeSec.ToString("0.00"); //adds the time to the pause menu
      timerText_end.text = levelTimeMin + ":" + levelTimeSec.ToString("0.00"); // asd the time to the end of the level screen


      if(levelWin == true)
      {
        winMenu.gameObject.SetActive (true); // if the player wins then the winscree is set to active
        Time.timeScale = 0f;
        isPaused = true;
      //  player.gameObject.SetActive (false); // turns off the player while in the menu
      }
      else if(levelLose == true)
      {
        loseMenu.gameObject.SetActive (true);// if the player loses then the lose screen is set to active
        Time.timeScale = 0f;
        isPaused = true;
      //  player.gameObject.SetActive (false); // turns off the player while in the menu
      }
      else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false) // if the escape is pressed and the game is not paused
      {
        PauseGame();
      }
      else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true && !tipOpen)// if escape is pressed and the game is paused
      {
        UnPauseGame();
      }

      if(colSpeed == true)
      {
        speedArt.gameObject.SetActive (true);
        speedText.gameObject.SetActive (true);
      }
      if(colJump == true)
      {
        jumpArt.gameObject.SetActive (true);
        jumpText.gameObject.SetActive (true);
      }
      if(colShield == true)
      {
        shieldArt.gameObject.SetActive (true);
        shieldText.gameObject.SetActive (true);
      }
      if(colHeart == true)
      {
        heartArt.gameObject.SetActive (true);
        heartText.gameObject.SetActive (true);
      }

      if(colSpeed == false) //turns off the UI bits
      {
        speedArt.gameObject.SetActive (false);
        speedText.gameObject.SetActive (false);
      }
      if(colJump == false)
      {
        jumpArt.gameObject.SetActive (false);
        jumpText.gameObject.SetActive (false);
      }
      if(colShield == false)
      {
        shieldArt.gameObject.SetActive (false);
        shieldText.gameObject.SetActive (false);
      }
      if(colHeart == false)
      {
        heartArt.gameObject.SetActive (false);
        heartText.gameObject.SetActive (false);
      }

    }

    public void ResetLevel()
    {
      levelLose = false; // reset the bool
      levelWin = false; // reset the bool
      UnPauseGame();
      PlayerMovement.startingSpawn.x = 0;
      PlayerMovement.startingSpawn.y = 0;
      player.transform.position = PlayerMovement.startingSpawn;//respawns for testing purposes
      HungerMeter.hungerLevel = 0;
      HungerMeter.isDead = true;
      loseMenu.gameObject.SetActive (false);
      Time.timeScale = 1; //returns time to the game
      isPaused = false;// un pauses time
      HungerMeter.lives = 4;
      PlayerMovement.respawnPoint = PlayerMovement.startingSpawn;// sets the player's respawn point back to the starting area and not thie last checkpoint
      levelTimeMin = 0;// resets the time to 0
      levelTimeSec = 0; //resets the time to 0
      TurnOffPowerUps();


    }
    public void TurnOffPowerUps() // call this to turn off all the power up indicaters in the UI
    {
      colJump = false; // youu have not collected the power ups now
      colHeart = false;//^
      colSpeed = false;//^
      colShield = false;//^
      PlayerMovement.Collected = false; // you have not lost your power up
      speedArt.gameObject.SetActive (false); // turns off the power ups because the player should not have any at the start
      speedText.gameObject.SetActive (false);


      /*

      jumpText.gameObject.SetActive (false);
      jumpArt.gameObject.SetActive (false);
      shieldText.gameObject.SetActive (false);
      shieldArt.gameObject.SetActive (false);
      heartText.gameObject.SetActive (false);
      heartArt.gameObject.SetActive (false);
      */
    }

    public void PauseGame() // for when the pause menu is opened
    {
      pauseMenu.gameObject.SetActive (true);
      Time.timeScale = 0f;
      isPaused = true;
    }
    public void UnPauseGame() // for when the pause menue is closed
    {
      pauseMenu.gameObject.SetActive (false);
      Time.timeScale = 1f;
      isPaused = false;
    }

}
