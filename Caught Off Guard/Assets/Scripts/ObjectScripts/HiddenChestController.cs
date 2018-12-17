using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenChestController : MonoBehaviour {

    public InventoryController Inventory;

    private bool playerNear = false;
    private bool hidden = true;
    private bool empty = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void PerformAction(string action) {
        if (!playerNear) {
            Inventory.SetText("Object is Too Far");
        }else if (hidden) {
            Inventory.SetText("You can't see that");
        }
        else {
            switch (action) {
                case "GRAB":
                    Inventory.DeselectItem();
                    if (empty) {
                        Inventory.SetText("You got what you need");
                    }
                    else {
                        Inventory.SetText("It's Locked");
                    }
                    break;
                case "CHEST_KEY":
                    Inventory.DeselectItem();
                    if (empty) {
                        Inventory.SetText("You got what you need");
                    }
                    else {
                        Inventory.SetText("You found a plane part!");
                        Inventory.AddItem("PLANE_PART1");
                        empty = true;
                    }
                    break;
                case "BONE":
                    Inventory.DeselectItem();
                    Inventory.SetText("It's not a Skeleton Key");
                    break;
                case "WOOD_AXE":
                case "TORCH":
                    Inventory.DeselectItem();
                    Inventory.SetText("You don't want to damage the contents");
                    break;
            }
        }
    }

    void DetectPlayer() {
        playerNear = true;
    }

    void UndetectPlayer() {
        playerNear = false;
    }

    public void Unhide() {
        hidden = false;
    }
}
