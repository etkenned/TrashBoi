using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mattress : MonoBehaviour
{
  public AudioClip BounceSound; // chewing sound
  public AudioSource BounceSource; // where the sound is played from
    // Start is called before the first frame update
    void Start()
    {
        BounceSource.clip = BounceSound;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.tag == "Player")
      {
        BounceSource.Play();
      }
    }

}
