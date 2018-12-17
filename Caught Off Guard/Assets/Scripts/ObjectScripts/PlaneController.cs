using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    public InventoryController Inventory;

    private TextMesh text;
    private bool playerNear = false;
    private int partsFixed = 0;

    // Use this for initialization
    void Start() {
        text = GetComponentInChildren<TextMesh>();
        text.text = "";
    }

    // Update is called once per frame
    void Update() {

    }

    public void PerformAction(string action) {
        if (playerNear) {
            switch (action) {
                case "GRAB":
                    Inventory.DeselectItem();
                    if (partsFixed < 3) {
                        text.text = "You've fixed " + partsFixed + "/3 parts";
                    }
                    else {
                        text.text = "YOU WIN";
                    }
                    break;
                case "PLANE_PART1":
                    Inventory.DeselectItem();
                    Inventory.SetText("You repair part of the plane");
                    Inventory.RemoveItem("PLANE_PART1");
                    break;
                case "PLANE_PART2":
                    Inventory.DeselectItem();
                    Inventory.SetText("You repair part of the plane");
                    Inventory.RemoveItem("PLANE_PART2");
                    break;
                case "PLANE_PART3":
                    Inventory.DeselectItem();
                    Inventory.SetText("You repair part of the plane");
                    Inventory.RemoveItem("PLANE_PART3");
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
