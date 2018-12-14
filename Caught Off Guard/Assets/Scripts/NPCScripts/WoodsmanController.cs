using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodsmanController : MonoBehaviour {

    public GameObject player;
    public InventoryController Inventory;

    private CharacterController charController;
    private TextMesh text;
    private bool seePlayer;
    private Queue<string> dialog = new Queue<string>();

    private bool gaveMap = false;
    private bool foundAxe = false;

    // Use this for initialization
    void Start () {
        seePlayer = true;
        charController = GetComponent<CharacterController>();
        text = GetComponentInChildren<TextMesh>();

        text.text = "You ok there? That looked like a bad crash.";
        dialog.Enqueue("Your plane's a bit busted up.\nBut it might be fixable with the right parts.");
        dialog.Enqueue("A few other planes crashed on this island before.\nYou might find the pieces you need there.");
        dialog.Enqueue("Here's a map of the island.\nI'll mark off where the other crashes are.");
        dialog.Enqueue("");

    }
	
	// Update is called once per frame
	void Update () {

    }

    void LateUpdate() {
        if (seePlayer) {
            Vector3 lookAt = player.transform.position;
            lookAt.y = transform.position.y;
            transform.LookAt(lookAt);
        }
        charController.SimpleMove(Vector3.zero);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            seePlayer = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            seePlayer = false;
            text.text = "";
        }
    }

    public void PerformAction(string action) {
        switch (action) {
            case "WOOD_AXE":
                text.text = "You found my axe!\nKeep it for now you might need it";
                foundAxe = true;
                Inventory.DeselectItem();
                break;
            case "SPEAK":
                player.SendMessage("TakeControl");
                AdvanceDialog();
                break;
            case "WOOD_CHUNK":
                text.text = "Not that great of a cut.\nYou keep it.";
                break;
        }
    }

    private void AdvanceDialog() {
        if(dialog.Count != 0) {
            text.text = dialog.Dequeue();
            if(dialog.Count == 0) {
                if (!gaveMap) {
                    Inventory.AddItem("ISLAND_MAP");
                    Inventory.SetText("Got Map");
                    gaveMap = true;
                }
                Inventory.DeselectItem();
                player.SendMessage("ReturnControl");
            }
        }else {
            if (!foundAxe) {
                text.text = "Have you found my axe yet?";
                dialog.Enqueue("I left it in the clearing.");
                dialog.Enqueue("Just follow the path past my cabin,\nyou can't miss it.");
                dialog.Enqueue("");
            }
            else {
                text.text = "How's it going with collecting those plane parts?";
                dialog.Enqueue("Just take another look at the map if you need to.");
                dialog.Enqueue("Also if you have some time,\nI'd appreciate some help cutting wood.");
                dialog.Enqueue("There's a chopping block on the other side of my cabin.");
                dialog.Enqueue("Feel free to take some pieces if you need them.");
                dialog.Enqueue("");
            }
        }
    }
}
