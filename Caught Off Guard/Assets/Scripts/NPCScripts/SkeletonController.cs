using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public GameObject player;
    public GameObject picture;
    public InventoryController Inventory;
    public GameObject normal;
    public GameObject pegleg;

    private CharacterController charController;
    private Queue<string> dialog = new Queue<string>();
    private TextMesh text;
    private bool playerNear;
    private bool gaveLeg;

    // Use this for initialization
    void Start () {
        charController = GetComponent<CharacterController>();
        text = GetComponentInChildren<TextMesh>();
        text.text = "";
        normal.SetActive(true);
        pegleg.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        charController.SimpleMove(Vector3.zero);
    }

    public void PerformAction(string action) {
        if (playerNear) {
            switch (action) {
                case "WOOD_CHUNK":
                    Inventory.DeselectItem();
                    Inventory.RemoveItem("WOOD_CHUNK");
                    Inventory.AddItem("BONE");
                    Inventory.SetText("Got Bone");
                    text.text = "<i>The skeleton excitedly takes the wood chunk\nand replaces it's own leg.\nIt seems happy.</i>";
                    normal.SetActive(false);
                    pegleg.SetActive(true);
                    gaveLeg = true;
                    LookAtObject(player);
                    break;
                case "SPEAK":
                    player.SendMessage("TakeControl");
                    LookAtObject(player);
                    AdvanceDialog();
                    break;
            }
        }
    }

    private void LookAtObject(GameObject o) {
        Vector3 lookAt = o.transform.position;
        lookAt.y = transform.position.y;
        transform.LookAt(lookAt);
    }

    void DetectPlayer() {
        playerNear = true;
    }

    void UndetectPlayer() {
        playerNear = false;
        LookAtObject(picture);
        text.text = "";
    }

    private void AdvanceDialog() {
        if (dialog.Count != 0) {
            text.text = dialog.Dequeue();
            if (dialog.Count == 0) {
                Inventory.DeselectItem();
                LookAtObject(picture);
                player.SendMessage("ReturnControl");
            }
        }
        else {
            text.text = "*click clack click*";
            dialog.Enqueue("<i>The skeleton turns to face you</i>");
            if (gaveLeg) {
                dialog.Enqueue("<i>It seems grateful</i>");
            }
            else {
                dialog.Enqueue("<i>It seems disintrested</i>");

            }
            dialog.Enqueue("");
        }
    }
}
