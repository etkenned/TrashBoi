using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer rend;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    IEnumerator FadeO() // fade the image out
    {
      for(float i = 1f; i >= -0.05f; i -= 0.05f)
      {
        Color c = rend.material.color;
        c.a = i;
        rend.material.color = c;
        yield return new WaitForSeconds (0.05f);
      }
    }

    IEnumerator FadeI() //fade the image in
    {
      for(float f = 0.05f; f <= 1; f += 0.05f)
      {
        Color c = rend.material.color;
        c.a = f;
        rend.material.color = c;
        yield return new WaitForSeconds (0.05f);
      }
    }

    public void endFading()
    {
      StartCoroutine("FadeI");
    }


    void OnTriggerEnter2D(Collider2D other) //enters the collider
    {
      if(other.tag == "Player")
      {
        StartCoroutine("FadeO");
      }
    }

    void OnTriggerExit2D(Collider2D other) // exits the collider
    {
      if(other.tag == "Player")
      {
        StartCoroutine("FadeI");
      }
    }

}
