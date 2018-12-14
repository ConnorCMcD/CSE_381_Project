using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour {

    public InventoryController Inventory;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void PerformAction(string action) {
        switch (action) {
            case "WOOD_AXE":
                Destroy(gameObject);
                Inventory.SetText("Chopped some wood");
                Inventory.AddItem("WOOD_CHUNK");
                Inventory.DeselectItem();
                break;
        }
    }
}
