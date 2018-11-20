using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PerformAction(string action)
    {
        switch (action)
        {
            case "Punch":
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;
        }
    }
}
