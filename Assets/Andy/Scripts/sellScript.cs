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
    public TextMeshProUGUI qualityText;     //text to show the quality of the selected item

    public InventoryController inventory;   //for getting the selected item's tile coordinates
    public InventoryItem currentItem;       //the currently selected item

    public GuildFunds guildFunds;           //for when we want to add gold to the guild funds
    public int goldValue;                   //total gold value of selected item
    public int qualValue;                   //gold value of selected item's base value multiplied with quality seen below
    public TextMeshProUGUI goldText;        //text to show gold value of selected item
    private merchantBase merchant;          //merchant selected for gold calculations
    public merchantBase[] merchantArray;    //array of merchants to select from based on specific buttons

    public float goodQuality = 1.5f;        //multiplier for good quality items
    public float greatQuality = 2f;         //multiplier for great quality items

    // Start is called before the first frame update
    void Start()
    {
        //reset panel to be clean
        currentItem = null;    
        currentItemImage.sprite = rclickImage;
        qualityText.text = "";
        goldText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //checks for when an item is selected by right clicking
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

            //calculating gold for the selected item
            CalculateGold();

            //display calculated gold
            goldText.text = goldValue + "g";
        }
        else
        {
            //if no item is selected, reset the panel
            currentItem = null;
            currentItemImage.sprite = rclickImage;
            qualityText.text = "";
            goldText.text = "";
        }
    }

    public void sellItem()
    {
        //adds gold value to guild funds and deletes item
        if (currentItem != null)
        {
            guildFunds.GainGold(goldValue);
            currentItem = null;
            currentItemImage.sprite = rclickImage;
            qualityText.text = "";
            goldText.text = "";
        }
    }

    public void Trash()
    {
        //deletes the currently selected item and resets the panel
        if (currentItem != null)
        {
            Destroy(currentItem.gameObject);
            currentItem = null;
            currentItemImage.sprite = rclickImage;
            qualityText.text = "";
            goldText.text = "";
        }
    }

    public void CheckMerchant(int merch)
    {
        //currently only 2 merchants. 0 is Alchemist and 1 is Fur merchant
        merchant = merchantArray[merch];
    }

    public void CalculateGold()
    {
        //multiplying the base value of the item with the quality modifier
        switch (currentItem.quality)
        {
            case Quality.Normal:
            qualValue = Mathf.RoundToInt(currentItem.itemData.baseValue);
            break;

            case Quality.Good:
            qualValue = Mathf.RoundToInt(currentItem.itemData.baseValue * goodQuality);
            break;

            case Quality.Great:
            qualValue = Mathf.RoundToInt(currentItem.itemData.baseValue * greatQuality);
            break;
        }

        //taking the qualValue from previous switch statement and
        //multiplying it with the merchant item type modifier to
        //calculate the final gold value
        switch (currentItem.itemData.itemType)
        {
            case ItemTypes.Plant:
            goldValue = Mathf.RoundToInt(qualValue * merchant.plantMod);
            break;

            case ItemTypes.Rock:
            goldValue = Mathf.RoundToInt(qualValue * merchant.rockMod);
            break;

            case ItemTypes.Animal:
            goldValue = Mathf.RoundToInt(qualValue * merchant.animalMod);
            break;

            case ItemTypes.Meat:
            goldValue = Mathf.RoundToInt(qualValue * merchant.meatMod);
            break;

            case ItemTypes.Fur:
            goldValue = Mathf.RoundToInt(qualValue * merchant.furMod);
            break;

            case ItemTypes.Eyes:
            goldValue = Mathf.RoundToInt(qualValue * merchant.eyeMod);
            break;

            case ItemTypes.Bones:
            goldValue = Mathf.RoundToInt(qualValue * merchant.boneMod);
            break;

            case ItemTypes.Ruby:
            goldValue = Mathf.RoundToInt(qualValue * merchant.rubyMod);
            break;

            case ItemTypes.Amethyst:
            goldValue = Mathf.RoundToInt(qualValue * merchant.amethystMod);
            break;

            case ItemTypes.Sapphire:
            goldValue = Mathf.RoundToInt(qualValue * merchant.sapphireMod);
            break;

            case ItemTypes.Topaz:
            goldValue = Mathf.RoundToInt(qualValue * merchant.topazMod);
            break;

            case ItemTypes.Flower:
            goldValue = Mathf.RoundToInt(qualValue * merchant.flowerMod);
            break;

            case ItemTypes.Fruit:
            goldValue = Mathf.RoundToInt(qualValue * merchant.fruitMod);
            break;

            case ItemTypes.Fibre:
            goldValue = Mathf.RoundToInt(qualValue * merchant.fibreMod);
            break;

            case ItemTypes.Leaves:
            goldValue = Mathf.RoundToInt(qualValue * merchant.leafMod);
            break;
        }
    }
}
