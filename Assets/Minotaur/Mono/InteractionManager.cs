using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InteractionManager
{
    [Inject]
    IInventoryScreenProvider inventoryScreenProvider;

    public void OpenInventory(Inventory inventory)
    {
        Debug.Log($"Opening inventory {inventory.Slots[0]}");
        var screen = inventoryScreenProvider.GetInventoryScreen(inventory);
        screen.Toggle(); //TODO: Toggle vs Open?
    }
}
