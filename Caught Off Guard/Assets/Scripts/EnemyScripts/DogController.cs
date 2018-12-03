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

    private enum State {IDLE, GUARDING, FOLLOWING, WAITING, BEGGING, ATTACKING, HUNTING};
    private State state;

    // Use this for initialization
    void Start () {
        state = State.IDLE;
        GetComponent<MeshRenderer>().material = normal;
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
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            transform.Rotate(90, 0, 0);
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
                        GetComponent<MeshRenderer>().material = angry;
                    }
                    else if (state == State.HUNTING || state == State.IDLE || state == State.WAITING)
                    {
                        Inventory.SetText("You can't reach the Dog.");
                    }
                }
                break;
            case "BONE":
                if (state != State.ATTACKING && state != State.HUNTING)
                {
                    if (state == State.FOLLOWING || state == State.BEGGING || state == State.GUARDING)
                    {
                        state = State.FOLLOWING;
                        Inventory.SetText("You Give the Dog the Bone.");
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
                break;
        }
    }

    public void DetectPlayer()
    {
        if(state == State.IDLE)
        {
            state = State.GUARDING;
        }
        else if(state == State.HUNTING)
        {
            state = State.ATTACKING;
        }
        else if(state == State.WAITING)
        {
            state = State.FOLLOWING;
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
