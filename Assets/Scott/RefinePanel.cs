using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RefinePanel : MonoBehaviour
{
    public Image currentItemImage;
    public Sprite rclickImage;
    public CameraSwitcher currentCamera;
    private bool baseImage;
    public TextMeshProUGUI qualityText;
    public InventoryController inventory;
    public SceneSwapper swapper;
    
    public Audiomanager audiomanager;

    public InventoryItem currentItem;

    // Start is called before the first frame update
    void Start()
    {
        currentItemImage.sprite = rclickImage;
        baseImage = true;
        currentItem = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCamera.currentCameraIndex != 3 && baseImage == false)
        {
            currentItemImage.sprite = rclickImage;
            qualityText.text = "";
            currentItem = null;
            baseImage = true;
        }

        if (currentCamera.currentCameraIndex == 3 && baseImage == true)
        {
            baseImage = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            RightMouseButtonPress();
        }
    }

    private void RightMouseButtonPress()
    {
        Vector2Int tileGridPosition = inventory.GetGridPosition();

        // Get the selected item from the inventory grid
        InventoryItem selectedInventoryItem = inventory.selectedItemGrid.GetItem(tileGridPosition.x, tileGridPosition.y);

        if (selectedInventoryItem != null)
        {
            // Update the current item in the RefinePanel
            currentItem = selectedInventoryItem;

            // Update the image in the RefinePanel
            currentItemImage.sprite = currentItem.itemData.itemIcon;

            // Update the quality text in the RefinePanel
            qualityText.text = currentItem.quality.ToString();
        }
        else
        {
            // If no item is selected, clear the RefinePanel
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
            // Optionally, update your UI elements to clear the displayed information.
            currentItemImage.sprite = rclickImage;
            qualityText.text = "";
        }
    }

    public void RefineMatch3()
    {
        if (currentItem != null)
        {
            if (currentItem.itemData.itemType == ItemTypes.Animal)
            {
                currentCamera.SwitchCanvasOrder(4);
                currentCamera.SwitchToCamera(4);
                audiomanager.CrossfadeMusic(3);
                StartCoroutine(SwapScene("Match3-Animal"));
                Destroy(currentItem.gameObject);
                currentItem = null;
                // Optionally, update your UI elements to clear the displayed information.
                currentItemImage.sprite = rclickImage;
                qualityText.text = "";
                
            }
            if (currentItem.itemData.itemType == ItemTypes.Plant)
            {
                currentCamera.SwitchCanvasOrder(4);
                currentCamera.SwitchToCamera(4);
                audiomanager.CrossfadeMusic(3);
                StartCoroutine(SwapScene("Match3-Plant"));
                Destroy(currentItem.gameObject);
                currentItem = null;
                // Optionally, update your UI elements to clear the displayed information.
                currentItemImage.sprite = rclickImage;
                qualityText.text = "";
                
            }
            if (currentItem.itemData.itemType == ItemTypes.Rock)
            {
                currentCamera.SwitchCanvasOrder(4);
                currentCamera.SwitchToCamera(4);
                audiomanager.CrossfadeMusic(3);
                StartCoroutine(SwapScene("Match3-Rock"));
                Destroy(currentItem.gameObject);
                currentItem = null;
                // Optionally, update your UI elements to clear the displayed information.
                currentItemImage.sprite = rclickImage;
                qualityText.text = "";
                
            }
        }
    }

    public IEnumerator SwapScene(string sceneToLoad)
    {
        yield return new WaitForSeconds(1f);

        swapper.LoadUnloadScene(sceneToLoad);
    }
}
