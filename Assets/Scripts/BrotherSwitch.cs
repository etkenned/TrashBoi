using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrotherSwitch : MonoBehaviour {
    // Start is called before the first frame update
    [System.Serializable] public struct Brother {
        string name;
        public float runSpeed;
        public float climbSpeed;
        public float jumpForce;
        public bool airControl;
        public int maxAirJumps;
        public float playerSize; //Atm just circle Collider radius
        public Sprite happy;
        public Sprite hungry;
    }
    public GameObject waitingBoiPrefab;

    public PlayerMovement playerMovement;
    public CharacterController2D characterController;
    public CircleCollider2D playerCollider;
    public HungerMeter hungerMeter;
    public Animator animator; // animator for the player

    public Brother[] brothers;
    Brother currentBrother;
    Brother CurrentBrother {
        get => currentBrother;
        set {
            currentBrother = value;
            PlayerMovement.runSpeed = value.runSpeed;
            playerMovement.climbSpeed = value.climbSpeed;
            characterController.jumpForce = value.jumpForce;
            characterController.airControl = value.airControl;
            characterController.maxAirJumps = value.maxAirJumps;
            if(value.maxAirJumps < characterController.numAirJumps) {
                characterController.numAirJumps = value.maxAirJumps;
            }
            playerCollider.radius = value.playerSize;
            hungerMeter.happyFace.GetComponent<Image>().sprite = value.happy;
            hungerMeter.hungryFace.GetComponent<Image>().sprite = value.hungry;
        }
    }
    private int currentBrotherIndex;

    void Start() {
        if(brothers.Length == 0) {
            //Do nothing: BrotherSwitch is not being used
        } else {
            currentBrother = brothers[0];
            currentBrotherIndex = 0;
        }
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerStay2D(Collider2D other)
    {
      if(other.tag == "BrotherSwap") // can only swap to brother at a changing station
      {
        if(Input.GetKeyDown(KeyCode.B) && currentBrotherIndex == 0) {
            SwitchBrother();
            GameObject waitingBoi = Instantiate(waitingBoiPrefab, transform.parent);
            waitingBoi.transform.position = transform.position;
            animator.SetBool("IsBrother", true);
        }
      }
    }


    public void SwitchBrother() {
        currentBrotherIndex = ++currentBrotherIndex % brothers.Length;
        CurrentBrother = brothers[currentBrotherIndex];
    }
}
