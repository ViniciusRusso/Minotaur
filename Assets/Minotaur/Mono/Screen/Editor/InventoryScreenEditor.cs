using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InventoryScreenTemplate))]
public class InventoryScreenTemplateEditor : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        var template = (InventoryScreenTemplate)target;

        var prefabType = PrefabUtility.GetPrefabAssetType(template);
        Debug.Log($"Prefab type: {prefabType}");
        var isEditingPrefab = prefabType == PrefabAssetType.NotAPrefab; //Yes, this feels backwards

        if (!isEditingPrefab && GUILayout.Button("ResetTemplate")) {
            //Reset GameObject to prefab state
            PrefabUtility.RevertObjectOverride(template.gameObject, InteractionMode.AutomatedAction);
        }


        if (isEditingPrefab && GUILayout.Button("Preview Slots")) {
            template.EditorPreviewSlots();
        }
    }
}
