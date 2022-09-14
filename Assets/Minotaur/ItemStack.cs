using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable enable
public class ItemStack
{
    public static ItemStack Empty { get => new ItemStack(new Item(){ name = "Empty", maxStackSize = 0, icon = null, prefab = null }, 0); }

    [SerializeField]
    Item item;
    [SerializeField]
    int count;


    public event System.Action<ItemStack> StackChanged = delegate { };

    public ItemStack(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }

    public Item Item { get => item; }
    public int Count { get => count; }

    public void Replace(ItemStack stack)
    {
        item = stack.item;
        count = stack.count; //TODO: Check if count is valid
    }

    public void Add(int amount)
    {
        if (!IsFull)
        {
            count += amount;
        }
    }

    public void Remove(int amount)
    {
        count -= amount;
        if (IsEmpty)
        {
            this.Replace(ItemStack.Empty);
        }
    }

    public bool IsEmpty { get => count <= 0; }
    public bool IsFull { get => count == (item.maxStackSize); }


    override public string ToString() => $"{item.name} x{count}";
    
}