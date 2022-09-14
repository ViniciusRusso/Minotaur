using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InventoryScreenTemplate : MonoBehaviour, IInventoryScreenProvider
{
    [SerializeField]
    GameObject titlebar;

    [SerializeField]
    GameObject slotHolder;

    [SerializeField]
    GameObject inventorySlotPrefab;

    [SerializeField]
    public Sprite testSprite;

    public int slotCount = 10;

    public void EditorPreviewSlots()
    {
        // If not in editor, do nothing
        if (!Application.isEditor || Application.isPlaying)
        {
            Debug.LogWarning("ResetTemplate() must be in editing mode");
            return;
        }

        // If we have a slot holder, destroy all children
        if (slotHolder != null)
        {
            var children = new List<GameObject>();
            foreach (Transform child in slotHolder.transform) children.Add(child.gameObject);
            foreach (GameObject child in children)
            {
                DestroyImmediate(child.gameObject);
            }

            var showItem = new Item() { name = "Test Item", maxStackSize = 10, icon = testSprite };

            // Create new slots
            for (int i = 0; i < slotCount; i++)
            {
                // Adds a prefab to the current prefab
                var slotUI = PrefabUtility.InstantiatePrefab(inventorySlotPrefab, slotHolder.transform) as GameObject;

                var newSlot = new Slot();
                newSlot.Stack = new ItemStack(showItem, i + 1);

                slotUI.GetComponent<SlotRenderer>().Slot = newSlot;
                slotUI.GetComponent<SlotRenderer>()?.RenderSlot();
                slotUI.name = $"Slot {i}";

            }
        }
    }

    public InventoryScreenTemplate GetInventoryScreen(Inventory inventory)
    {
        Debug.Log("TODO: GetInventoryScreen()");

        var children = new List<GameObject>();
        foreach (Transform child in slotHolder.transform) children.Add(child.gameObject);

        int invSize = inventory.Size;
        int slotCount = children.Count;

        if (invSize > slotCount)
        {
            Debug.LogWarning($"Inventory size ({invSize}) is larger than slot count ({slotCount})");
        }

        inventory.Stacks[0].Item.icon = testSprite;

        for (int i = 0; i < invSize; i++)
        {
            var slotUI = children[i];
            var slot = inventory.Slots[i];
            slotUI.GetComponent<SlotRenderer>().Slot = slot;
            slotUI.GetComponent<SlotRenderer>()?.RenderSlot();
        }
        
        return this; //TODO: change return type to InventoryScreen
    }

    public void Toggle()
    {
        Debug.Log("TODO: Toggle()");
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
