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

    public void Start() {
        charController = GetComponent<CharacterController>();
    }
    public void Update() {
        float verticalInput = Input.GetAxis(verticalName) * movementSpeed;
        float horizontalInput = Input.GetAxis(horizontalName) * movementSpeed;

        Vector3 fowardMovement = Vector3.Normalize(Vector3.ProjectOnPlane(camera.transform.forward, xzPlaneNormal)) * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;

        charController.SimpleMove(fowardMovement + rightMovement);
    }
}