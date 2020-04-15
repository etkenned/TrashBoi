using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButton : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip ButtonSound; // chewing sound
    public AudioSource ButtonSource; // where the sound is played from
    public Sprite PressedButton;
    public Sprite UnpressedButton;
    private SpriteRenderer ButtonSprite;
    public static bool isPressed;
    void Start()
    {
        isPressed = false;
        ButtonSprite = GetComponent <SpriteRenderer> (); //used for changing the art when activated
        ButtonSource.clip = ButtonSound;
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.tag == "Player")//if the player collides with the checkpoint
      {
        ButtonSprite.sprite = PressedButton;// swaps sprites for checkpoint
        isPressed = true;
        ButtonSource.Play();
      }
    }

    void OnTriggerExit2D(Collider2D other)
    {
      if(other.tag == "Player")
      {
        ButtonSprite.sprite = UnpressedButton;
      }
    }


}
