using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour {
    private class COGObject
    {
        public string name;
        public GameObject thing;
        public List<string> allowedActions = new List<string>();

        public COGObject(string name, GameObject thing)
        {
            this.name = name;
            this.thing = thing;
        }
        public void PerformAction(string action)
        {
            thing.SendMessage("PerformAction", action);
        }
    }


    public GameObject testblock, PLANK, GUARD_DOG, LOST_AXE, BRAMBLE, SKELETON;
    public PlayerController player;
    
    private Dictionary<string, COGObject> objects = new Dictionary<string, COGObject>();

	// Use this for initialization
	void Start () {
        objects.Add("TEST_BLOCK", new COGObject("Block", testblock));

        COGObject plank = new COGObject("Plank", PLANK);
        plank.allowedActions.Add("PUNCH");
        objects.Add("PLANK", plank);

        COGObject dog = new COGObject("Dog", GUARD_DOG);
        dog.allowedActions.Add("PUNCH");
        dog.allowedActions.Add("BONE");
        dog.allowedActions.Add("WOOD_AXE");
        objects.Add("GUARD_DOG", dog);

        COGObject axe = new COGObject("Axe", LOST_AXE);
        axe.allowedActions.Add("GRAB");
        objects.Add("LOST_AXE", axe);

        COGObject bramble = new COGObject("Bramble", BRAMBLE);
        bramble.allowedActions.Add("WOOD_AXE");
        bramble.allowedActions.Add("PUNCH");
        objects.Add("BRAMBLE", bramble);

        COGObject skeleton = new COGObject("Skeleton", SKELETON);
        skeleton.allowedActions.Add("WOOD_AXE");
        objects.Add("SKELETON", skeleton);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public string GetObjectName(string objectid)
    {
        COGObject cobject;
        if(objects.TryGetValue(objectid, out cobject))
        {
            return cobject.name;
        }
        return "Error";
    }

    public bool TryPerformAction(string objectid, string actionid)
    {
        COGObject cobject;
        if (objects.TryGetValue(objectid, out cobject))
        {
            if (cobject.allowedActions.Contains(actionid))
            {
                cobject.PerformAction(actionid);
                player.TriggerAnimation(actionid);
                return true;
            }
        }
        return false;
    }
}
