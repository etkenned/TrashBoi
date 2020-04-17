using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Animator animator;
    private BoxCollider2D GateCollider;
    // Start is called before the first frame update
    void Start()
    {
      GateCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GateButton.isPressed)
        {
          animator.SetTrigger("Opening");
          GateCollider.enabled = false;
        }

    }
}
