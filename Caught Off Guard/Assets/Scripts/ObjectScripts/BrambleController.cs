using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrambleController : MonoBehaviour {

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
            case "WOOD_AXE":
                Destroy(gameObject);
                Inventory.SetText("Chopped Down Bramble");
                break;
            case "PUNCH":
                Inventory.SetText("OW! That hurt your hands");
                break;
        }
    }
}
