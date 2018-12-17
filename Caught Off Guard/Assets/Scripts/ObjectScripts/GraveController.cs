using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveController : MonoBehaviour {

    public InventoryController Inventory;
    public GameObject dirt;

    private TextMesh text;
    private bool playerNear = false;
    private bool foundDirt = false;

    // Use this for initialization
    void Start() {
        text = GetComponentInChildren<TextMesh>();
        text.text = "";
        dirt.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void PerformAction(string action) {
        switch (action) {
            case "GRAB":
                if (playerNear) {
                    Inventory.DeselectItem();
                    Inventory.SetText("Read the gravestone");
                    if (foundDirt) {
                        text.text = "The gravestone reads:\n'Jimmy: Our little captain'";
                    }
                    else {
                        text.text = "The gravestone reads:\n'Jimmy: Our little captain'\nYou notice some loose dirt\nin front of the grave.";
                        dirt.SetActive(true);
                        foundDirt = true;
                    }
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
        text.text = "";
    }
}
