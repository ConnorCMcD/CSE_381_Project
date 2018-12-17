using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour {

    public InventoryController Inventory;
    public GameObject Hidden_Chest;

    private bool playerNear = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void PerformAction(string action) {
        if (playerNear) {
            switch (action) {
                case "GRAB":
                    Inventory.DeselectItem();
                    Inventory.SetText("Feels like something's behind it");
                    break;
                case "TORCH":
                    Destroy(gameObject);
                    Inventory.DeselectItem();
                    Inventory.SetText("You burn the flag away");
                    Hidden_Chest.SendMessage("Unhide");
                    break;
            }
        }
        else {
            Inventory.SetText("Object is Too Far");
        }
    }

    void DetectPlayer() {
        playerNear = true;
    }

    void UndetectPlayer() {
        playerNear = false;
    }
}
