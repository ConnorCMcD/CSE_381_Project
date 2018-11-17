using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

    private bool itemSelected;
    private GameObject text;
    private GameObject[] items = new GameObject[4];

	// Use this for initialization
	void Start () {
        itemSeletected = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SelectItem(string itemName)
    {
        itemSelected = true;
    }
}
