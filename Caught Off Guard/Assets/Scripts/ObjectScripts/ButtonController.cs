using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public InventoryController Inventory;
    public GameObject Door;

    private bool playerNear = false;
    private bool pressed = false;

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
                case "PUNCH":
                    Inventory.DeselectItem();
                    if (pressed) {
                        Inventory.SetText("It's already pressed down");
                    }
                    else {
                        Inventory.SetText("You push the button");
                        Destroy(Door);
                    }
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
