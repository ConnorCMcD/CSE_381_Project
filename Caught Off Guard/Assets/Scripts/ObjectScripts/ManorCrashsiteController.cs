using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManorCrashsiteController : MonoBehaviour {

    public InventoryController Inventory;

    private TextMesh text;
    private bool playerNear;

    // Use this for initialization
    void Start() {
        text = GetComponentInChildren<TextMesh>();
        text.text = "";
    }

    // Update is called once per frame
    void Update() {

    }

    public void PerformAction(string action) {
        switch (action) {
            case "GRAB":
                if (playerNear) {
                    Inventory.DeselectItem();
                    Inventory.SetText("Searched the wreck");
                    text.text = "Looks like someone already took\nthe parts.  Maybe I can find\na clue nearby.";
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
        text.text = "";
    }
}
