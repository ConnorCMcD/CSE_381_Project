using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardDoorController : MonoBehaviour {

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
                case "PUNCH":
                    Inventory.DeselectItem();
                    Inventory.SetText("Sounds hollow");
                    break;
                case "WOOD_AXE":
                    Inventory.DeselectItem();
                    Inventory.SetText("Don't risk damaging the Axe");
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
