using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour {

    public InventoryController Inventory;

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
                Destroy(gameObject);
                Inventory.AddItem("WOOD_AXE");
                Inventory.SetText("Got Axe");
                break;
        }
    }
}
