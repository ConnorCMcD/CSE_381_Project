using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveCrashsiteController : MonoBehaviour {

    public InventoryController Inventory;

    private bool playerNear = false;
    private bool partTaken = false;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    public void PerformAction(string action) {
        switch (action) {
            case "GRAB":
                if (playerNear) {
                    Inventory.DeselectItem();
                    if (partTaken) {
                        Inventory.SetText("Already got this part.");
                    }
                    else {
                        Inventory.SetText("Found a plane part!");
                        Inventory.AddItem("PLANE_PART3");
                        partTaken = true;
                    }
                }
                else {
                    Inventory.SetText("Object is Too Far");
                }
                break;
        }
    }

    void DetectPlayer() {
        playerNear = true;
    }

    void UndetectPlayer() {
        playerNear = false;
    }
}