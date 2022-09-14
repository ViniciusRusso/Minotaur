using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [Inject]
    Inventory inventory;

    [Inject]
    InteractionManager interactionManager;
    
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            interactionManager.OpenInventory(inventory);
        }    

        if (Input.GetKeyDown(KeyCode.Z))
        {
            inventory.Stacks[0].Add(1);
        }    
    }
}
