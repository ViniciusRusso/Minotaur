using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    // ItemType type;
    public string name;
    public int maxStackSize;
    public Sprite icon;
    public GameObject prefab;

    public ItemStack DefaultStack { get => new ItemStack(this, 1); }
}
