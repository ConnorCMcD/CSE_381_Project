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


    public GameObject GUARD_DOG, LOST_AXE, BRAMBLE, SKELETON, WOODSMAN, WOOD_LOG,
        TUNNEL, FAKE_WALL, SECRET_DOOR, BREAKABLE_WALL, CANNON, CANNON_BALL, LOCKED_DOOR,
        CHEST, PLAYER_PLANE, CRASHSITE_1, CRASHSITE_2, CRASHSITE_3;
    public PlayerController player;
    
    private Dictionary<string, COGObject> objects = new Dictionary<string, COGObject>();

	// Use this for initialization
	void Start () {
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

        COGObject woodsman = new COGObject("Woodsman", WOODSMAN);
        woodsman.allowedActions.Add("PUNCH");
        woodsman.allowedActions.Add("SPEAK");
        woodsman.allowedActions.Add("WOOD_AXE");
        woodsman.allowedActions.Add("WOOD_CHUNK");
        objects.Add("WOODSMAN", woodsman);

        COGObject log = new COGObject("Log", WOOD_LOG);
        log.allowedActions.Add("WOOD_AXE");
        objects.Add("WOOD_LOG", log);

        COGObject tunnel = new COGObject("Tunnel Path", TUNNEL);
        objects.Add("TUNNEL", tunnel);

        COGObject shortcut = new COGObject("Weird Wall", FAKE_WALL);
        shortcut.allowedActions.Add("SPEAK");
        shortcut.allowedActions.Add("PUNCH");
        shortcut.allowedActions.Add("WOOD_AXE");
        objects.Add("FAKE_WALL", shortcut);

        COGObject gravedoor = new COGObject("Indented Stone", SECRET_DOOR);
        gravedoor.allowedActions.Add("PUNCH");
        gravedoor.allowedActions.Add("WOOD_AXE");
        objects.Add("SECRET_DOOR", gravedoor);

        COGObject breakwall = new COGObject("Cracked Wall", BREAKABLE_WALL);
        breakwall.allowedActions.Add("PUNCH");
        breakwall.allowedActions.Add("WOOD_AXE");
        breakwall.allowedActions.Add("GRAB");
        objects.Add("BREAKABLE_WALL", breakwall);
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
