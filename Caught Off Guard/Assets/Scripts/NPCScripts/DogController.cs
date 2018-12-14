using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    public GameObject player;
    public InventoryController Inventory;
    public float speed;
    public Material normal;
    public Material happy;
    public Material angry;

    private CharacterController charController;
    private TextMesh text;
    private enum State {IDLE, GUARDING, FOLLOWING, WAITING, BEGGING, ATTACKING, HUNTING};
    private State state;

    // Use this for initialization
    void Start () {
        charController = GetComponent<CharacterController>();
        text = GetComponentInChildren<TextMesh>();
        state = State.IDLE;
        GetComponent<MeshRenderer>().material = normal;

        text.text = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 enemyPos = transform.position;
        if (state == State.GUARDING || state == State.ATTACKING || state == State.FOLLOWING || state == State.BEGGING)
        {
            Vector3 lookAt = player.transform.position;
            lookAt.y = transform.position.y;
            transform.LookAt(lookAt);
            if (state == State.ATTACKING || state == State.FOLLOWING)
            {
                charController.SimpleMove(transform.forward * speed);
            }
            transform.Rotate(90, 0, 0);
            charController.SimpleMove(Vector3.zero);
        }
        else {
            charController.SimpleMove(Vector3.zero);
        }
    }

    public void PerformAction(string action)
    {
        switch (action)
        {
            case "PUNCH":
                if (state != State.ATTACKING && state != State.HUNTING) {
                    if (state == State.FOLLOWING || state == State.BEGGING || state == State.GUARDING)
                    {
                        state = State.ATTACKING;
                        Inventory.SetText("You have angered the Dog.");
                        text.text = "YAP";
                        GetComponent<MeshRenderer>().material = angry;
                    }
                    else if (state == State.HUNTING || state == State.IDLE || state == State.WAITING)
                    {
                        Inventory.SetText("You can't reach the Dog.");
                    }
                }
                Inventory.DeselectItem();
                break;
            case "BONE":
                if (state != State.ATTACKING && state != State.HUNTING)
                {
                    if (state == State.FOLLOWING || state == State.BEGGING || state == State.GUARDING)
                    {
                        state = State.FOLLOWING;
                        Inventory.SetText("You Give the Dog the Bone.");
                        text.text = "*crunch crunch*";
                        GetComponent<MeshRenderer>().material = happy;
                    }
                    else
                    {
                        Inventory.SetText("You can't reach the Dog.");
                    }
                }
                else
                {
                    Inventory.SetText("The Dog is too Angry.");
                }
                Inventory.DeselectItem();
                break;
            case "WOOD_AXE":
                if (state == State.HUNTING || state == State.IDLE || state == State.WAITING)
                {
                    Inventory.SetText("You can't reach the Dog.");
                }
                else
                {
                    Destroy(gameObject);
                    if (state == State.FOLLOWING || state == State.BEGGING)
                    {
                        Inventory.SetText("YOU MONSTER");
                    }
                    else
                    {
                        Inventory.SetText("You Killed the Dog");
                    }
                }
                Inventory.DeselectItem();
                break;
        }
    }

    public void DetectPlayer()
    {
        if(state == State.IDLE)
        {
            state = State.GUARDING;
            text.text = "GRRRRrrr...";
        }
        else if(state == State.HUNTING)
        {
            state = State.ATTACKING;
            text.text = "BARK BARK";
        }
        else if(state == State.WAITING)
        {
            state = State.FOLLOWING;
            text.text = "*pant pant*";
        }
    }

    public void UndetectPlayer()
    {
        if (state == State.GUARDING)
        {
            state = State.IDLE;
        }
        else if (state == State.ATTACKING)
        {
            state = State.HUNTING;
        }
        else if (state == State.FOLLOWING)
        {
            state = State.WAITING;
        }
        text.text = "";
    }

    public void NearPlayer()
    {
        if (state == State.FOLLOWING)
        {
            state = State.BEGGING;
        }
    }

    public void AwayPlayer()
    {
        if (state == State.BEGGING )
        {
            state = State.FOLLOWING;
        }
    }
}
