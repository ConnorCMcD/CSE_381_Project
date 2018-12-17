using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour {

    public InventoryController Inventory;
    
    private bool playerNear = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void PerformAction(string action) {
        switch (action) {
            case "GRAB":
                if (playerNear) {
                    Destroy(gameObject);
                    Inventory.DeselectItem();
                    Inventory.SetText("Unburied a key");
                    Inventory.AddItem("CHEST_KEY");
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
    }
}
