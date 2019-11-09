using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
  public PlatformEffector2D effector;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>(); // sets the platform's variable in unity to a veriable in C#
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
          effector.rotationalOffset = 180; // pressing down will cause the platforms collider to switch so you can fall through it
        }
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
          effector.rotationalOffset = 0; // pressing up or jump will turn the platform back to normal
        }
    }
}
