using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelController : MonoBehaviour {

    public InventoryController Inventory;
    public GameObject player;
    public GameObject TunnelExitDoor;
    public GameObject TunnelExit;

    private bool playerNear = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void PerformAction(string action) {
        if (playerNear) {
            player.SendMessage("TakeTunnel");
            TunnelExitDoor.SetActive(false);
            TunnelExit.SetActive(true);
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
