using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public string horizontalName;
    public string verticalName;
    public float movementSpeed;
    public GameObject Camera;
    public GameObject Tunnel_Exit;
    public GameObject Tunnel_Entrance;

    private CharacterController charController;
    private Vector3 xzPlaneNormal = new Vector3(0f, 1f, 0f);
    private Animator anim;
    private bool controllable;

    public void Start() {
        charController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        controllable = false;
    }
    public void Update() {
        if (controllable)
        {
            float verticalInput = Input.GetAxis(verticalName);
            float horizontalInput = Input.GetAxis(horizontalName);

            Vector3 fowardDirection = Vector3.Normalize(Vector3.ProjectOnPlane(Camera.transform.forward, xzPlaneNormal)) * verticalInput;
            Vector3 sideDirection = Camera.transform.right * horizontalInput;
            Vector3 direction = Vector3.Normalize(fowardDirection + sideDirection);

            if (verticalInput + horizontalInput != 0.0)
            {
                transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
                anim.SetBool("Moving", true);
            }
            else
            {
                anim.SetBool("Moving", false);
            }

            charController.SimpleMove(direction * movementSpeed);
        }
        else {
            charController.SimpleMove(Vector3.zero);
        }
    }

    public void TriggerAnimation(string actionid)
    {
        switch (actionid)
        {
            case "PUNCH":
                controllable = false;
                anim.SetBool("Moving", false);
                anim.SetTrigger("Punch");
                break;
            case "GRAB":
                controllable = false;
                anim.SetBool("Moving", false);
                anim.SetTrigger("Grab");
                break;
        }
    }

    public void ReturnControl()
    {
        controllable = true;
    }

    public void TakeControl() {
        controllable = false;
    }

    public void TakeTunnel() {
        transform.position = Tunnel_Exit.transform.position;
    }

    public void TakePassage() {
        transform.position = Tunnel_Entrance.transform.position;
    }
}