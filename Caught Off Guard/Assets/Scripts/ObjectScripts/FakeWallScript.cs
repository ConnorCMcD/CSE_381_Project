using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWallScript : MonoBehaviour {

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
                case "SPEAK":
                    Inventory.DeselectItem();
                    Inventory.SetText("'Open Seasame' doesn't work");
                    break;
                case "PUNCH":
                    Inventory.DeselectItem();
                    Inventory.SetText("Feels solid");
                    break;
                case "WOOD_AXE":
                    Inventory.DeselectItem();
                    Inventory.SetText("Don't damage the Axe");
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
