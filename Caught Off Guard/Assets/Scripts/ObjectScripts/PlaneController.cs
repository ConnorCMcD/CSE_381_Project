using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneController : MonoBehaviour {

    public InventoryController Inventory;

    private TextMesh text;
    private bool playerNear = false;
    private int partsFixed = 0;

    // Use this for initialization
    void Start() {
        text = GetComponentInChildren<TextMesh>();
        text.text = "";
    }

    // Update is called once per frame
    void Update() {

    }

    public void PerformAction(string action) {
        if (playerNear) {
            switch (action) {
                case "GRAB":
                    Inventory.DeselectItem();
                    if (partsFixed < 3) {
                        text.text = "You've fixed " + partsFixed + "/3 parts";
                    }
                    else {
                        SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
                    }
                    break;
                case "PLANE_PART1":
                    Inventory.DeselectItem();
                    Inventory.SetText("You repair part of the plane");
                    Inventory.RemoveItem("PLANE_PART1");
                    partsFixed++;
                    break;
                case "PLANE_PART2":
                    Inventory.DeselectItem();
                    Inventory.SetText("You repair part of the plane");
                    Inventory.RemoveItem("PLANE_PART2");
                    partsFixed++;
                    break;
                case "PLANE_PART3":
                    Inventory.DeselectItem();
                    Inventory.SetText("You repair part of the plane");
                    Inventory.RemoveItem("PLANE_PART3");
                    partsFixed++;
                    break;
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
        text.text = "";
    }
}
