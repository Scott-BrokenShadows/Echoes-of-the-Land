using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHighlight : MonoBehaviour
{
    [SerializeField] RectTransform highlighter;

    public void Show(bool b)
    {
        highlighter.gameObject.SetActive(b);
    }

    public void SetSize(InventoryItem targetItem)
    {
        Vector2 size = new Vector2();
        size.x = targetItem.WIDTH * ItemGrid.tileSizeWidth;
        size.y = targetItem.HEIGHT * ItemGrid.tileSizeHeight;
        highlighter.sizeDelta = size;
    }

    public void SetPosition(ItemGrid targetGrid, InventoryItem targetItem)
    {
        Vector2 pos = targetGrid.CalculatePositionOnGrid(targetItem, targetItem.onGridPositionX, targetItem.onGridPositionY);
        highlighter.position = pos;
    }

    public void SetParent(ItemGrid targetGrid)
    {
        if(targetGrid == null) { return; }
        highlighter.SetParent(targetGrid.GetComponent<RectTransform>());
    }

    public void SetPosition(ItemGrid targetGrid, InventoryItem targetItem, int posX, int posY)
    {
        //Vector2 pos = targetGrid.CalculatePositionOnGrid(targetItem, posX, posY);
        //highlighter.localPosition = pos;

        Vector2 pos = targetGrid.CalculatePositionOnGrid(targetItem, posX, posY);
        RectTransform targetRectTransform = targetItem.GetComponent<RectTransform>();

        // Convert the position from local space to screen space
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(null, pos);

        // Convert the screen position to local position within the canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle(highlighter.parent as RectTransform, screenPos, null, out pos);

        // Set the local position of the highlighter
        highlighter.localPosition = pos;
    }

}
