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
        offset.x = -1 * distance / Mathf.Sqrt(3);
        offset.y = distance / Mathf.Sqrt(3);
        offset.z = -1 * distance / Mathf.Sqrt(3);
    }

    void FixedUpdate() {
        //Keyboard controls
        float revolveHorizontal = Input.GetAxis("CameraHorizontal");
        float revolveVertical = Input.GetAxis("CameraVertical");

        offset = Quaternion.AngleAxis(speed * revolveHorizontal, Vector3.up) * offset;
        offset = Quaternion.AngleAxis(speed * revolveVertical, transform.right) * offset;

        //Mouse controls
        if (Input.mousePosition.x > Screen.width - 30)
        {
            offset = Quaternion.AngleAxis(-speed, Vector3.up) * offset;
        }
        else if (Input.mousePosition.x < 30)
        {
            offset = Quaternion.AngleAxis(speed, Vector3.up) * offset;
        }
        if (Input.mousePosition.y > Screen.height - 30 && offset.y < distance - 0.1)
        {
            offset = Quaternion.AngleAxis(speed, transform.right) * offset;
        }
        else if (Input.mousePosition.y < 30 && offset.y > 0)
        {
            offset = Quaternion.AngleAxis(-speed, transform.right) * offset;
        }
    }

    // Update is called once per frame
    void LateUpdate () {
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform);
    }
}
