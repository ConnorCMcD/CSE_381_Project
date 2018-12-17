using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour {

    public InventoryController Inventory;
    public GameObject Skeleton;
    public GameObject Entrance;
    public GameObject CrackedWall;

    private bool playerNear = false;
    private bool loaded = false;
    private bool skeletonKilled = false;
    private int target = 0;

    // Use this for initialization
    void Start() {
        Vector3 lookAt = Entrance.transform.position;
        lookAt.y = transform.position.y;
        transform.LookAt(lookAt);
    }

    // Update is called once per frame
    void Update() {

    }

    public void PerformAction(string action) {
        if (playerNear) {
            switch (action) {
                case "GRAB":
                    Inventory.SetText("You rotate the cannon");
                    SwitchTarget();
                    break;
                case "CANNON_BALL":
                    Inventory.DeselectItem();
                    Inventory.SetText("You load the cannon");
                    Inventory.RemoveItem("CANNON_BALL");
                    loaded = true;
                    break;
                case "TORCH":
                    Inventory.DeselectItem();
                    if(!loaded) {
                        Inventory.SetText("The cannon isn't loaded");
                    }else if(target == 1) {
                        Inventory.SetText("You fire, destroying a wall");
                        loaded = false;
                        Destroy(CrackedWall);
                    }else if(target == 2 && !skeletonKilled) {
                        Inventory.SetText("You blow up the skeleton");
                        loaded = false;
                        Skeleton.SendMessage("Die");
                        skeletonKilled = true;
                    }
                    else {
                        Inventory.SetText("There's nothing to hit");
                    }
                    break;

            }
        }
        else {
            Inventory.SetText("Object is Too Far");
        }
    }

    private void SwitchTarget() {
        target = (target + 1) % 3;
        Vector3 lookAt;
        switch (target) {
            case 0:
                lookAt = Entrance.transform.position;
                lookAt.y = transform.position.y;
                transform.LookAt(lookAt);
                break;
            case 1:
                lookAt = CrackedWall.transform.position;
                lookAt.y = transform.position.y;
                transform.LookAt(lookAt);
                break;
            case 2:
                lookAt = Skeleton.transform.position;
                lookAt.y = transform.position.y;
                transform.LookAt(lookAt);
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
