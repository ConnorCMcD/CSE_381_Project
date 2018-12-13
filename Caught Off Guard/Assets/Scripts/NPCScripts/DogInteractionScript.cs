using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogInteractionScript : MonoBehaviour {
    //Detects when player enters dog's interaction radius
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.parent.SendMessage("NearPlayer");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.parent.SendMessage("AwayPlayer");
        }
    }
}
