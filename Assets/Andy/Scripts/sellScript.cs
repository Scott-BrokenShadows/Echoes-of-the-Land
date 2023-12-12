using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class sellScript : MonoBehaviour
{
    public Image currentItemImage;          //image of the currently selected item
    public Sprite rclickImage;              //image for when no item is selected
    public TextMeshProUGUI qualityText;      //text to show the quality of the selected item

    public InventoryController inventory;
    public InventoryItem currentItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RightMouseButtonPress();
        }
    }

    private void RightMouseButtonPress()
    {
        Vector2Int tileGridPosition = inventory.GetGridPosition();

        InventoryItem selectedInventoryItem = inventory.selectedItemGrid.GetItem(tileGridPosition.x, tileGridPosition.y);
            
        if (selectedInventoryItem != null)
        {
            //this updates the current item to the one selected by right clicking
            currentItem = selectedInventoryItem;

            //updates item icon to the one selected by right clicking
            currentItemImage.sprite = currentItem.itemData.itemIcon;

            //updates the text to show the item's quality
            qualityText.text = currentItem.quality.ToString();

            //do gold funds transfer here
        }
        else
        {
            currentItem = null;
            currentItemImage.sprite = rclickImage;
            qualityText.text = "";
        }
    }
}
