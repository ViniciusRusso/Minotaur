using System.Collections;
using System.Collections.Generic;
using Zenject;
using UnityEngine;

#nullable enable
public class Inventory
{
    List<Slot> slots;
    int size;

    public Inventory([Inject(Id = "Size", Optional = true)] int size = 5)
    {
        this.size = size;
        var stacks = new List<Slot>();
        for (int i = 0; i < size; i++) {
            stacks.Add(new Slot());
            Debug.Log($"Added stack {i}");
        }
        this.slots = stacks;
    }

    public int Size { get => size; }
    public IReadOnlyList<Slot> Slots { get => slots; }
    public IReadOnlyList<ItemStack> Stacks { get => slots.ConvertAll(s => s.Stack); } //TODO: only expose slots, not stacks

}
