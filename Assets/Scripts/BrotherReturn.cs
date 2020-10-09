using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherReturn : MonoBehaviour {
    public static bool playerExited = false;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && playerExited) {
            collision.gameObject.GetComponent<BrotherSwitch>().SwitchBrother();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            playerExited = true;
        }
    }
}
