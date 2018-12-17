using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueController : MonoBehaviour {

    public InventoryController Inventory;
    public GameObject Metal_Ball;

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
                case "TORCH":
                    Destroy(gameObject);
                    Inventory.DeselectItem();
                    Inventory.SetText("Burned down the statue");
                    Metal_Ball.SendMessage("CanReach");
                    break;
                case "WOOD_AXE":
                    Destroy(gameObject);
                    Inventory.DeselectItem();
                    Inventory.SetText("Chopped down the statue");
                    Metal_Ball.SendMessage("CanReach");
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
