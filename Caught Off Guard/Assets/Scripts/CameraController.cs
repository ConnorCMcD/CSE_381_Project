using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float distance;
    public float speed;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset.x = 0;
        offset.y = distance / Mathf.Sqrt(2);
        offset.z = distance / Mathf.Sqrt(2);
    }

    void FixedUpdate() {
        float revolveHorizontal = Input.GetAxis("CameraHorizontal");
        float revolveVertical = Input.GetAxis("CameraVertical");

        offset = Quaternion.AngleAxis(speed * revolveHorizontal, Vector3.up) * offset;
        offset = Quaternion.AngleAxis(speed * revolveVertical, transform.right) * offset;
    }

    // Update is called once per frame
    void LateUpdate () {
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform);
    }
}
