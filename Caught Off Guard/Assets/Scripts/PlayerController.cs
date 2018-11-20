using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public string horizontalName;
    public string verticalName;
    public float movementSpeed;
    public GameObject camera;

    private CharacterController charController;
    private Vector3 xzPlaneNormal = new Vector3(0f, 1f, 0f);
    private Animator anim;

    public void Start() {
        charController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    public void Update() {
        float verticalInput = Input.GetAxis(verticalName);
        float horizontalInput = Input.GetAxis(horizontalName);

        Vector3 fowardDirection = Vector3.Normalize(Vector3.ProjectOnPlane(camera.transform.forward, xzPlaneNormal)) * verticalInput;
        Vector3 sideDirection = camera.transform.right * horizontalInput;
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
}