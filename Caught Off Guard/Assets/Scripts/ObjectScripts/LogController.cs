using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour {

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
            case "WOOD_AXE":
                if (playerNear) {
                    Destroy(gameObject);
                    Inventory.SetText("Chopped some wood");
                    Inventory.AddItem("WOOD_CHUNK");
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
