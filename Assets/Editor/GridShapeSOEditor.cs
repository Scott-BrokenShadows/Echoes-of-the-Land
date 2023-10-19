using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridShapeSO))]
[CanEditMultipleObjects]
public class GridShapeSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GridShapeSO gridShape = (GridShapeSO)target;

        int gridSize = gridShape.size;

        if (gridShape.gridSelection == null || gridShape.gridSelection.Length != gridSize * gridSize)
        {
            gridShape.Initialize();
        }

        // Display the 'size' field
        gridSize = EditorGUILayout.IntField("Grid Size", gridSize);

        if (gridSize != gridShape.size)
        {
            // If 'size' is changed, update the gridSelection array
            gridShape.size = gridSize;
            gridShape.Initialize();
        }

        EditorGUILayout.LabelField("Grid Selection:");

        EditorGUI.BeginChangeCheck();

        for (int y = 0; y < gridSize; y++)
        {
            EditorGUILayout.BeginHorizontal();

            for (int x = 0; x < gridSize; x++)
            {
                bool isSelected = gridShape.IsCellSelected(x, y);
                bool newSelection = EditorGUILayout.Toggle(isSelected);

                if (newSelection != isSelected)
                {
                    gridShape.ToggleCell(x, y);
                }
            }

            EditorGUILayout.EndHorizontal();
        }

        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(target);
        }
    }
}
