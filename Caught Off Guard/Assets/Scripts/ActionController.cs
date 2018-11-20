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


    public GameObject testblock;
    public GameObject PLANK;
    public GameObject GUARD_DOG;
    
    private Dictionary<string, COGObject> objects = new Dictionary<string, COGObject>();

	// Use this for initialization
	void Start () {
        objects.Add("TEST_BLOCK", new COGObject("Block", testblock));
        COGObject plank = new COGObject("Plank", PLANK);
        plank.allowedActions.Add("Punch");
        objects.Add("PLANK", plank);
        COGObject dog = new COGObject("Dog", GUARD_DOG);
        dog.allowedActions.Add("Punch");
        dog.allowedActions.Add("Bone");
        objects.Add("GUARD_DOG", dog);
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

    public string PerformAction(string objectid, string action)
    {
        COGObject cobject;
        if (objects.TryGetValue(objectid, out cobject))
        {
            if (cobject.allowedActions.Contains(action))
            {
                cobject.PerformAction(action);
                return "Used " + action + " On " + cobject.name;
            }
            return "Action Not Allowed";
        }
        return "Error";
    }
}
