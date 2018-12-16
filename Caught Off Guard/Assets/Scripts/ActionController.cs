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
        TUNNEL, FAKE_WALL, BUTTON, SECRET_DOOR, SECRET_PATH, BREAKABLE_WALL, 
        CANNON, CANNON_BALL, GOLD_CHEST, SECRET_CHEST, FLAG, STATUE, TORCH, 
        GRAVE, LOOSE_DIRT, PLAYER_PLANE, CRASHSITE_1, CRASHSITE_2, CRASHSITE_3;
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
        skeleton.allowedActions.Add("SPEAK");
        skeleton.allowedActions.Add("WOOD_CHUNK");
        objects.Add("SKELETON", skeleton);

        COGObject woodsman = new COGObject("Woodsman", WOODSMAN);
        woodsman.allowedActions.Add("PUNCH");
        woodsman.allowedActions.Add("SPEAK");
        woodsman.allowedActions.Add("WOOD_AXE");
        woodsman.allowedActions.Add("WOOD_CHUNK");
        objects.Add("WOODSMAN", woodsman);

        COGObject log = new COGObject("Log", WOOD_LOG);
        log.allowedActions.Add("WOOD_AXE");
        log.allowedActions.Add("TORCH");
        objects.Add("WOOD_LOG", log);

        COGObject tunnel = new COGObject("Tunnel Path", TUNNEL);
        objects.Add("TUNNEL", tunnel);

        COGObject secretpath = new COGObject("Secret Passage", SECRET_PATH);
        objects.Add("SECRET_PATH", secretpath);

        COGObject shortcut = new COGObject("Weird Wall", FAKE_WALL);
        shortcut.allowedActions.Add("SPEAK");
        shortcut.allowedActions.Add("PUNCH");
        shortcut.allowedActions.Add("WOOD_AXE");
        objects.Add("FAKE_WALL", shortcut);

        COGObject button = new COGObject("Button", BUTTON);
        button.allowedActions.Add("PUNCH");
        button.allowedActions.Add("GRAB");
        objects.Add("BUTTON", button);

        COGObject gravedoor = new COGObject("Indented Stone", SECRET_DOOR);
        gravedoor.allowedActions.Add("PUNCH");
        gravedoor.allowedActions.Add("WOOD_AXE");
        objects.Add("SECRET_DOOR", gravedoor);

        COGObject breakwall = new COGObject("Cracked Wall", BREAKABLE_WALL);
        breakwall.allowedActions.Add("PUNCH");
        breakwall.allowedActions.Add("WOOD_AXE");
        breakwall.allowedActions.Add("GRAB");
        objects.Add("BREAKABLE_WALL", breakwall);

        COGObject cannon = new COGObject("Cannon", CANNON);
        cannon.allowedActions.Add("GRAB");
        cannon.allowedActions.Add("CANNON_BALL");
        cannon.allowedActions.Add("TORCH");
        objects.Add("CANNON", cannon);

        COGObject cannonball = new COGObject("Metal Ball", CANNON_BALL);
        cannonball.allowedActions.Add("GRAB");
        objects.Add("CANNON_BALL", cannonball);

        COGObject torch = new COGObject("Torch", TORCH);
        torch.allowedActions.Add("GRAB");
        objects.Add("TORCH", torch);

        COGObject statue = new COGObject("Metal Ball", STATUE);
        statue.allowedActions.Add("WOOD_AXE");
        statue.allowedActions.Add("TORCH");
        objects.Add("STATUE", statue);

        COGObject goldchest = new COGObject("Chest of Gold", GOLD_CHEST);
        goldchest.allowedActions.Add("GRAB");
        objects.Add("GOLD_CHEST", goldchest);

        COGObject secretchest = new COGObject("Chest", SECRET_CHEST);
        secretchest.allowedActions.Add("GRAB");
        secretchest.allowedActions.Add("KEY");
        secretchest.allowedActions.Add("BONE");
        objects.Add("SECRET_CHEST", secretchest);

        COGObject flag = new COGObject("Pirate Flag", FLAG);
        flag.allowedActions.Add("TORCH");
        flag.allowedActions.Add("GRAB");
        objects.Add("FLAG", flag);

        COGObject grave = new COGObject("Gravestone", GRAVE);
        grave.allowedActions.Add("GRAB");
        objects.Add("GRAVE", grave);

        COGObject dirt = new COGObject("Loose Dirt", LOOSE_DIRT);
        dirt.allowedActions.Add("GRAB");
        objects.Add("LOOSE_DIRT", dirt);

        COGObject pplane = new COGObject("Your Plane", PLAYER_PLANE);
        pplane.allowedActions.Add("PLANE_PART1");
        pplane.allowedActions.Add("PLANE_PART2");
        pplane.allowedActions.Add("PLANE_PART3");
        pplane.allowedActions.Add("GRAB");
        objects.Add("PLAYER_PLANE", pplane);

        COGObject crash1 = new COGObject("Plane Wreck", CRASHSITE_1);
        crash1.allowedActions.Add("GRAB");
        objects.Add("CRASHSITE_1", crash1);

        COGObject crash2 = new COGObject("Plane Wreck", CRASHSITE_2);
        crash2.allowedActions.Add("GRAB");
        objects.Add("CRASHSITE_2", crash2);

        COGObject crash3 = new COGObject("Plane Wreck", CRASHSITE_3);
        crash3.allowedActions.Add("GRAB");
        objects.Add("CRASHSITE_3", crash3);
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
