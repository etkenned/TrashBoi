using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  public float damageAmount;// how much damage the ememy will deal to the hunger meter
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
      if(other.tag == "Player")
      {
        HungerMeter.hungerLevel -= damageAmount; //subtracts the damage amount from the hunger lever
        Debug.Log("Ouch you took some damage");
      }
    }
}
