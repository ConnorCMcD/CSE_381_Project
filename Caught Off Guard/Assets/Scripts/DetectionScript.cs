using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour {
    //Detects when player enters dog's tracking radius
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            transform.parent.SendMessage("DetectPlayer");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.parent.SendMessage("UndetectPlayer");
        }
    }
}
