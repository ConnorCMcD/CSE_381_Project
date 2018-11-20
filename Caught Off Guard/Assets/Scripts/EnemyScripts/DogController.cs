using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Material normal;
    public Material happy;
    public Material angry;

    private enum State {IDLE, TRACKING, WAITING, ATTACKING, HUNTING};
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
        if (state == State.TRACKING || state == State.ATTACKING || state == State.WAITING)
        {
            Vector3 lookAt = player.transform.position;
            lookAt.y = transform.position.y;
            transform.LookAt(lookAt);
            if (state == State.TRACKING || state == State.ATTACKING)
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
            case "Punch":
                if (state != State.ATTACKING && state != State.HUNTING) {
                    GetComponent<MeshRenderer>().material = angry;
                    if (state == State.TRACKING || state == State.WAITING)
                    {
                        state = State.ATTACKING;
                    }
                    else
                    {
                        state = State.HUNTING;
                    }
                }
                break;
            case "Bone":
                if (state != State.ATTACKING && state != State.HUNTING)
                {
                    GetComponent<MeshRenderer>().material = happy;
                }
                break;
        }
    }

    public void DetectPlayer()
    {
        if(state == State.IDLE)
        {
            state = State.TRACKING;
        }else if(state == State.HUNTING)
        {
            state = State.ATTACKING;
        }
    }

    public void UndetectPlayer()
    {
        if (state == State.TRACKING)
        {
            state = State.IDLE;
        }
        else if (state == State.ATTACKING)
        {
            state = State.HUNTING;
        }
    }

    public void NearPlayer()
    {
        if (state == State.TRACKING)
        {
            state = State.WAITING;
        }
    }

    public void AwayPlayer()
    {
        if (state == State.WAITING)
        {
            state = State.TRACKING;
        }
    }
}
