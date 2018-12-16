using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour {

    public InventoryController Inventory;

    private bool playerNear = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void PerformAction(string action)
    {
        switch (action)
        {
            case "GRAB":
                if (playerNear) {
                    Destroy(gameObject);
                    Inventory.SetText("Got Axe!");
                    Inventory.AddItem("WOOD_AXE");
                    Inventory.DeselectItem();
                }
                else {
                    Inventory.SetText("Object is Too Far");
                }
                break;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            playerNear = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            playerNear = false;
        }
    }
}
