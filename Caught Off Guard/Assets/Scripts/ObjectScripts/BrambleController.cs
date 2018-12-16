using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrambleController : MonoBehaviour {

    public InventoryController Inventory;

    private bool playerNear;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void PerformAction(string action) {
        if (playerNear) {
            switch (action) {
                case "WOOD_AXE":
                    Destroy(gameObject);
                    Inventory.SetText("Chopped Down Bramble");
                    Inventory.DeselectItem();
                    break;
                case "PUNCH":
                    Inventory.SetText("OW! That hurt your hands");
                    Inventory.DeselectItem();
                    break;
            }
        }
        else {
            Inventory.SetText("Object is too far");
        }
    }

    void DetectPlayer() {
        playerNear = true;
    }

    void UndetectPlayer() {
        playerNear = false;
    }
}
