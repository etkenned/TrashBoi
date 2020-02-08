using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turotial : MonoBehaviour
{
    public GameObject trashTip;
    public bool TipOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        TipOpen = false;
        Time.timeScale = 1;
        trashTip.gameObject.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey(KeyCode.E) && TipOpen == true)
      {
        TipOpen = false;
        Time.timeScale = 1;
        trashTip.gameObject.SetActive (false);
        MenuManager.isPaused = false;
        MenuManager.tipOpen = false;
        Destroy(gameObject);
      }
    }
    void OnTriggerEnter2D(Collider2D other)// if the player collides with the tutorial collider
    {
      if(TipOpen == false)
      {
        MenuManager.isPaused = true;
        MenuManager.tipOpen = true;
        TipOpen = true; // the tip window is up
        trashTip.gameObject.SetActive (true); // shows the tip on screen
        Time.timeScale = 0; // pauses time so the player can read the tutorial
      }

    }

}
