using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public GridShapeSO gridShape; // Reference to the GridShapeSO for defining the shape

    internal void Set(GridShapeSO gridShape)
    {
        this.gridShape = gridShape;

        // Set the sprite and size based on the item data
        if (gridShape != null && gridShape.itemData != null)
        {
            ItemDataSO itemData = gridShape.itemData;
            GetComponent<Image>().sprite = itemData.itemIcon;

            Vector2 size = new Vector2();
            //size.x = itemData.width * ItemGrid.tileSizeWidth;
            //size.y = itemData.height * ItemGrid.tileSizeHeight;
            GetComponent<RectTransform>().sizeDelta = size;
        }
    }
}
