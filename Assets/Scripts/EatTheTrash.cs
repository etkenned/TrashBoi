using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EatTheTrash : MonoBehaviour
{
  public float trashValue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
      Destroy (gameObject); // removes trash when collected
      HungerMeter.hungerLevel += trashValue; // adds 5 points to the hunger level in HungerMeter.cs 
      Debug.Log("Yum, you ate some garbage");
    }
}
