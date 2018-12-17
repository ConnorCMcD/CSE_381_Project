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
    public GameObject deadbones;
    public GameObject Metal_Ball;

    private CharacterController charController;
    private Queue<string> dialog = new Queue<string>();
    private TextMesh text;
    private bool playerNear;
    private bool gaveLeg;
    private bool dead;

    // Use this for initialization
    void Start () {
        charController = GetComponent<CharacterController>();
        text = GetComponentInChildren<TextMesh>();
        text.text = "";
        normal.SetActive(true);
        pegleg.SetActive(false);
        deadbones.SetActive(false);
        Metal_Ball.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        charController.SimpleMove(Vector3.zero);
    }

    public void PerformAction(string action) {
        if (playerNear) {
            switch (action) {
                case "WOOD_CHUNK":
                    if (!dead) {
                        Inventory.DeselectItem();
                        Inventory.RemoveItem("WOOD_CHUNK");
                        Inventory.AddItem("BONE");
                        Inventory.SetText("Got Bone");
                        text.text = "<i>The skeleton excitedly takes the wood chunk\nand replaces it's own leg.\nIt seems happy.</i>";
                        normal.SetActive(false);
                        pegleg.SetActive(true);
                        gaveLeg = true;
                        LookAtObject(player);
                    }
                    break;
                case "SPEAK":
                    if (!dead) {
                        player.SendMessage("TakeControl");
                        LookAtObject(player);
                        AdvanceDialog();
                    }
                    break;
                case "GRAB":
                    Inventory.DeselectItem();
                    if (dead) {
                        if (!gaveLeg) {
                            Inventory.AddItem("BONE");
                            Inventory.SetText("You got a Bone...");
                            gaveLeg = true;
                        }
                        else {
                            Inventory.SetText("You don't need another bone");
                        }
                    }
                    else {
                        Inventory.SetText("You can't do that right now");
                    }
                    break;
            }
        }
        else {
            Inventory.SetText("You are too far away for that");
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
        if (!dead) {
            LookAtObject(picture);
        }
        text.text = "";
    }

    public void Die() {
        dead = true;
        normal.SetActive(false);
        pegleg.SetActive(false);
        deadbones.SetActive(true);
        Metal_Ball.SetActive(true);
        Metal_Ball.SendMessage("CanReach");
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
