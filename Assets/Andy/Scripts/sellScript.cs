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

    public GuildFunds guildFunds;
    public int goldValue;
    public GameObject merchant;

    // Start is called before the first frame update
    void Start()
    {
        currentItemImage.sprite = rclickImage;
        currentItem = null;
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
        //getting tile coordinates of selected item
        Vector2Int tileGridPosition = inventory.GetGridPosition();

        //getting the selected item from inventory grid
        InventoryItem selectedInventoryItem = inventory.selectedItemGrid.GetItem(tileGridPosition.x, tileGridPosition.y);
            
        if (selectedInventoryItem != null)
        {
            //this updates the current item to the one selected by right clicking
            currentItem = selectedInventoryItem;

            //updates item icon to the one selected by right clicking
            currentItemImage.sprite = currentItem.itemData.itemIcon;

            //updates the text to show the item's quality
            qualityText.text = currentItem.quality.ToString();


            //Mathf.RoundToInt(goldValue);
            //guildFunds.GainGold(goldValue);
        }
        else
        {
            //if no item is selected, clear the panel
            currentItem = null;
            currentItemImage.sprite = rclickImage;
            qualityText.text = "";
        }
    }

    public void Trash()
    {
        if (currentItem != null)
        {
            Destroy(currentItem.gameObject);
            currentItem = null;
            currentItemImage.sprite = rclickImage;
            qualityText.text = "";
        }
    }

    public void CalculateGold()
    {
        switch (currentItem.quality)
        {
            case Quality.Normal:
            goldValue = Mathf.RoundToInt(currentItem.itemData.baseValue);
            break;
            case Quality.Good:
            goldValue = Mathf.RoundToInt(currentItem.itemData.baseValue * 1.5f);
            break;
            case Quality.Great:
            goldValue = Mathf.RoundToInt(currentItem.itemData.baseValue * 2f);
            break;
        }
    }

}
