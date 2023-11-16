using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public ItemDataSO itemData;
    public Quality quality;

    public int HEIGHT
    {
        get
        {
            if(rotated == false)
            {
                return itemData.height;
            }
            return itemData.width;
        }
    }
    public int WIDTH
    {
        get
        {
            if (rotated == false)
            {
                return itemData.width;
            }
            return itemData.height;
        }
    }

    public int onGridPositionX;
    public int onGridPositionY;

    public bool rotated = false;

    internal void Set(ItemDataSO itemData)
    {
        this.itemData = itemData;

        GetComponent<Image>().sprite = itemData.itemIcon;
        SetSize(itemData.width, itemData.height);
    }

    internal void SetSize(int width, int height)
    {
        CanvasScaler canvasScaler = GetComponentInParent<CanvasScaler>();

        // Get the scale factor from the Canvas Scaler
        float canvasScaleFactor = canvasScaler.referenceResolution.x / Screen.width;

        // Apply the scale factor to the size calculation
        Vector2 size = new Vector2(width * ItemGrid.tileSizeWidth * canvasScaleFactor, height * ItemGrid.tileSizeHeight * canvasScaleFactor);

        // Set the size taking the canvas scale factor into account
        GetComponent<RectTransform>().sizeDelta = size;

        // Adjust the image scale
        Image image = GetComponent<Image>();
        image.rectTransform.localScale = new Vector3(1 / canvasScaleFactor, 1 / canvasScaleFactor, 1f);
    }

    internal void Rotate()
    {
        rotated = !rotated;
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.rotation = Quaternion.Euler(0, 0, rotated == true ? 90f : 0f);
    }

    private void Awake()
    {
        quality = Quality.Normal;
    }
}
