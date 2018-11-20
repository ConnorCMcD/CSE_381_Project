﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {
    private class Item
    {
        public string name;
        public Sprite icon;
        public Item(string name, Sprite icon)
        {
            this.name = name;
            this.icon = icon;
        }
    }

    public Text text;
    public Image ItemSlot1;
    public Image ItemSlot2;
    public Image ItemSlot3;
    public Image ItemSlot4;
    public Sprite Grab_Icon;
    public Sprite Punch_Icon;
    public Sprite Bone_Icon;
    public Sprite Key_Icon;
    public ActionController ActionHandler;
    public int test;

    private ArrayList items = new ArrayList();
    private Item selectedItem;
    private int wheelIndex;

	// Use this for initialization
	void Start () {
        selectedItem = null;
        items.Add(new Item("Grab", Grab_Icon));
        items.Add(new Item("Punch", Punch_Icon));
        items.Add(new Item("Key", Key_Icon));
        items.Add(new Item("Bone", Bone_Icon));
        wheelIndex = 0;
        ItemSlot1.sprite = ((Item)items[0]).icon;
        ItemSlot2.sprite = ((Item)items[1]).icon;
        ItemSlot3.sprite = ((Item)items[2]).icon;
        ItemSlot4.sprite = ((Item)items[3]).icon;
    }
	
	// Update is called once per frame
	void Update () {
		
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
            text.text = ActionHandler.PerformAction(objectid, selectedItem.name);
        }
        selectedItem = null;
    }
}
