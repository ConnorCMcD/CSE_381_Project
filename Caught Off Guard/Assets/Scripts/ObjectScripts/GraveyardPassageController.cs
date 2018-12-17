using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardPassageController : MonoBehaviour {

    public GameObject player;
    public InventoryController Inventory;

    private bool playerNear = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void PerformAction(string action) {
        if (playerNear) {
            player.SendMessage("TakePassage");
        }
        else {
            Inventory.SetText("Object is too far");
        }
    }

    void DetectPlayer() {
        playerNear = true;
    }

    void UndetectPlayer() {
        playerNear = false;
    }
}
