using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSFX : MonoBehaviour
{
  public AudioClip BoxSound; // chewing sound
  public AudioSource BoxSource; // where the sound is played from
    // Start is called before the first frame update
    void Start()
    {
        BoxSource.clip = BoxSound;
    }

    void OnTriggerStay2D(Collider2D other)
    {
      if(other.tag == "Player" && Input.GetKey(KeyCode.E))
      {
        BoxSource.Play();
      }
    }
}
