using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {
    private class Item
    {
        public string id;
        public string name;
        public Sprite icon;
        public Item(string id, string name, Sprite icon)
        {
            this.id = id;
            this.name = name;
            this.icon = icon;
        }
    }

    public Text text;
    public Image ItemSlot1, ItemSlot2, ItemSlot3, ItemSlot4;
    public Sprite Grab_Icon, Punch_Icon, Speak_Icon, Bone_Icon, Key_Icon, Axe_Icon,
        Map_Icon, Wood_Icon, Torch_Icon, Ball_Icon, Part_Icon;
    public ActionController ActionHandler;

    private Dictionary<string, Item> itemLookUp = new Dictionary<string, Item>();
    private ArrayList items = new ArrayList();
    private Image[] itemslots = new Image[4];
    private Item selectedItem;
    private int wheelIndex;

	// Use this for initialization
	void Start () {
        selectedItem = null;

        //starting items
        Item grab = new Item("GRAB", "Grab", Grab_Icon);
        itemLookUp.Add("GRAB", grab);
        items.Add(grab);
        Item punch = new Item("PUNCH", "Punch", Punch_Icon);
        itemLookUp.Add("PUNCH", punch);
        items.Add(punch);
        Item speak = new Item("SPEAK", "Speak", Speak_Icon);
        itemLookUp.Add("SPEAK", speak);
        items.Add(speak);

        //other items
        itemLookUp.Add("WOOD_AXE", new Item("WOOD_AXE", "Axe", Axe_Icon));
        itemLookUp.Add("DOOR_KEY", new Item("DOOR_KEY", "Key", Key_Icon));
        itemLookUp.Add("BONE", new Item("BONE", "Bone", Bone_Icon));
        itemLookUp.Add("ISLAND_MAP", new Item("ISLAND_MAP", "Map", Map_Icon));
        itemLookUp.Add("WOOD_CHUNK", new Item("WOOD_CHUNK", "Chunk of Wood", Wood_Icon));
        itemLookUp.Add("TORCH", new Item("TORCH", "Torch", Torch_Icon));
        itemLookUp.Add("CANNON_BALL", new Item("CANNON_BALL", "Metal Ball", Ball_Icon));
        itemLookUp.Add("PLANE_PART1", new Item("PLANE_PART1", "Plane Part", Part_Icon));
        itemLookUp.Add("PLANE_PART2", new Item("PLANE_PART2", "Plane Part", Part_Icon));
        itemLookUp.Add("PLANE_PART3", new Item("PLANE_PART3", "Plane Part", Part_Icon));

        //setting up inventory wheel
        wheelIndex = 0;
        ItemSlot1.sprite = ((Item)items[0]).icon;
        ItemSlot2.sprite = ((Item)items[1]).icon;
        ItemSlot3.sprite = ((Item)items[2]).icon;
        ItemSlot4.enabled = false;
        //ItemSlot4.sprite = ((Item)items[3]).icon;
        itemslots[0] = ItemSlot1;
        itemslots[1] = ItemSlot2;
        itemslots[2] = ItemSlot3;
        itemslots[3] = ItemSlot4;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem(string itemID)
    {
        Item toAdd;
        if (itemLookUp.TryGetValue(itemID, out toAdd))
        {
            items.Add(toAdd);
            UpdateInventory();
        }
    }

    public void RemoveItem(string itemID)
    {
        Item toRemove;
        if(itemLookUp.TryGetValue(itemID, out toRemove))
        {
            items.Remove(toRemove);
            UpdateInventory();
        }
    }

    public void SelectItem(int itemkey)
    {
        selectedItem = (Item)items[wheelIndex + itemkey];
        text.text = "Use " + selectedItem.name;
    }

    public void DeselectItem()
    {
        selectedItem = null;
        text.text = "";
    }

    public void HoverItem(int itemkey)
    {
        if (selectedItem == null)
        {
            text.text = ((Item)items[wheelIndex + itemkey]).name;
        }
    }

    public void Unhover()
    {
        if (selectedItem == null)
        {
            text.text = "";
        }
        else
        {
            text.text = "Use " + selectedItem.name;
        }
    }

    public void HoverObject(string objectid)
    {
        if(selectedItem == null)
        {
            text.text = ActionHandler.GetObjectName(objectid);
        }
        else
        {
            text.text = "Use " + selectedItem.name + " On " + ActionHandler.GetObjectName(objectid);
        }
    }

    public void SelectObject(string objectid)
    {
        if (selectedItem != null)
        {
            if (!ActionHandler.TryPerformAction(objectid, selectedItem.id))
            {
                text.text = "Cannot Use " + selectedItem.name + " On " + ActionHandler.GetObjectName(objectid);
            }
        }
    }

    public void CycleInventory(int index)
    {
        wheelIndex += index;
        if (wheelIndex >= items.Count)
            wheelIndex = 0;
        else if (wheelIndex < 0)
            wheelIndex = (items.Count - 1) - (items.Count - 1) % 4;
        UpdateInventory();
    }

    private void UpdateInventory()
    {
        for (int i = 0; i < 4; i++)
        {
            if (wheelIndex + i < items.Count)
            {
                itemslots[i].enabled = true;
                itemslots[i].sprite = ((Item)items[wheelIndex + i]).icon;
            }
            else
            {
                itemslots[i].enabled = false;
            }
        }
    }

    public void SetText(string message)
    {
        text.text = message;
    }
}
