using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  public GameObject player;
  private Vector3 offset;

    // Start is called before the first frame update

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 0.2f);
    }
    /*
    void OnTriggerStay2D(Collider2D other)
    {
      if(other.tag == "Player") // player walks into the triggers at the edge of the camera
      {
        if(transform.position.x < other.transform.position.x) // Player is on the right side of the camera
        {
          transform.Translate (Vector2.right * 8f * Time.deltaTime); //moves to the right
        }
        else if(transform.position.x > other.transform.position.x) // Player is on the left side
        {
          transform.Translate (-Vector2.right * 8f * Time.deltaTime); //moves to the right
        }

        if(transform.position.y < other.transform.position.y) // player is above
        {
          transform.Translate (Vector2.up * 8f * Time.deltaTime); //moves camera up
        }
        else if(transform.position.y - other.transform.position.y > 2.5f) // player is down
        {
          transform.Translate (-Vector2.up * 8f * Time.deltaTime); //moves camera down
        }

      }
    }
    */
}
