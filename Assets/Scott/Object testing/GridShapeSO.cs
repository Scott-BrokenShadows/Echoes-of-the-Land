using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Grid Shape", menuName = "Inventory System/Grid Shape")]
public class GridShapeSO : ScriptableObject
{
    public int size = 1; // The size of the grid (e.g., 3x3, 4x4, etc.)
    public bool[] gridSelection; // A flattened representation of the selected grid cells
    public ItemDataSO itemData; // Reference to the ItemDataSO to define the item's appearance

    public void Initialize()
    {
        gridSelection = new bool[size * size];

        // Initialize all cells to false
        for (int i = 0; i < gridSelection.Length; i++)
        {
            gridSelection[i] = false;
        }
    }

    public bool IsCellSelected(int x, int y)
    {
        if (gridSelection == null || x < 0 || x >= size || y < 0 || y >= size)
        {
            return false;
        }

        // Convert 2D grid coordinates to 1D array index
        int index = x + y * size;
        return gridSelection[index];
    }

    public void ToggleCell(int x, int y)
    {
        if (gridSelection == null || x < 0 || x >= size || y < 0 || y >= size)
        {
            return;
        }

        // Convert 2D grid coordinates to 1D array index
        int index = x + y * size;
        gridSelection[index] = !gridSelection[index];
    }
}

