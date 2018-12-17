﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {
    public GameObject Camera;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate() {
        Vector3 lookAt = Camera.transform.position;
        transform.LookAt(lookAt);
        transform.Rotate(0, 180, 0);
    }
}
