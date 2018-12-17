using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour {

    public InventoryController Inventory;

    private bool playerNear = false;
    private bool reachable = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void PerformAction(string action) {

        if (playerNear) {
            if (reachable) {
                switch (action) {
                    case "GRAB":
                        Destroy(gameObject);
                        Inventory.DeselectItem();
                        Inventory.AddItem("CANNON_BALL");
                        Inventory.SetText("Got Metal Ball");
                        break;
                }
            }
            else {
                Inventory.SetText("It's too high to reach");
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

    public void CanReach() {
        reachable = true;
    }
}
