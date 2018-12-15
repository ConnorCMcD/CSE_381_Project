using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public InventoryController Inventory;

    private CharacterController charController;

    // Use this for initialization
    void Start () {
        charController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        charController.SimpleMove(Vector3.zero);
    }

    public void PerformAction(string action)
    {
        switch (action)
        {
            case "WOOD_AXE":
                Destroy(gameObject);
                Inventory.AddItem("BONE");
                Inventory.SetText("Killed Skeleton. Got Bone.");
                Inventory.DeselectItem();
                break;
        }
    }
}
