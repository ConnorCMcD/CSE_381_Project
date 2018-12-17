using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldChestController : MonoBehaviour {

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
            switch (action) {
                case "GRAB":
                    Inventory.DeselectItem();
                    Inventory.SetText("The coins are... plastic");
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
