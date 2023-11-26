using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{ 
    
    public ItemGrid selectedItemGrid;

    //public ItemGrid SelectedItemGrid
    //{
    //    get => selectedItemGrid;
    //    set
    //    {
    //        selectedItemGrid = value;
    //        inventoryHighlight.SetParent(value);
    //    }
    //}

    InventoryItem selectedItem;
    InventoryItem overlapItem;
    RectTransform rectTransform;

    public List<ItemDataSO> items;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform canvasTransform;

    Vector2Int oldPosition;
    InventoryHighlight inventoryHighlight;
    private Vector2Int originalGridPosition; // where the item was picked up from

    public bool isWorldSpace = true;
    public Canvas inventoryCanvas;

    private void Awake()
    {
        
    }

    private void Start()
    {
        inventoryHighlight = GetComponent<InventoryHighlight>();
        selectedItemGrid = FindObjectOfType<ItemGrid>();
        if (selectedItemGrid == null)
        {
            Debug.LogError("ItemGrid not found in the scene.");
            // You might want to handle this case appropriately, like disabling certain functionality.
        }
    }
    public void Update()
    {
        ItemIconDrag();


        if (Input.GetKeyDown(KeyCode.R))
        {
            RotateItem();
        }

        if (selectedItemGrid == null)
        {
            inventoryHighlight.Show(false);
            return;
        }

        HandleHighlight();

        if (Input.GetMouseButtonDown(0))
        {
            if (isWorldSpace == false)
            {
                LeftMouseButtonPress();
            }
        }

        if (inventoryCanvas.renderMode == RenderMode.WorldSpace && !isWorldSpace)
        {
            isWorldSpace = true;
        }
        else if (inventoryCanvas.renderMode != RenderMode.WorldSpace && isWorldSpace)
        {
            isWorldSpace = false;
        }

        if (isWorldSpace && selectedItem != null)
        {
            PlaceItem(originalGridPosition);
        }
    }

    private void RotateItem()
    {
        if(selectedItem == null) { return; }

        selectedItem.Rotate();
    }

    public void InsertAdventurerItem(ItemDataSO itemSO, Quality quality)
    {
        if (selectedItemGrid == null) 
        {
            return; 
        }

        CreateItem(itemSO);
        InventoryItem itemToInsert = selectedItem;
        selectedItem = null;
        itemToInsert.quality = quality; // Set the quality of the item
        InsertItem(itemToInsert);
    }

    private void InsertItem(InventoryItem itemToInsert)
    {
        if(selectedItemGrid == null) { return; }
        
        Vector2Int? posOnGrid = selectedItemGrid.FindSpaceForObject(itemToInsert);

        if(posOnGrid == null) { return; }

        selectedItemGrid.PlaceItem(itemToInsert, posOnGrid.Value.x, posOnGrid.Value.y);
    }

    InventoryItem itemToHighlight;

    private void HandleHighlight()
    {
        Vector2Int positionOnGrid = GetGridPosition();

        // Perform bounds checking to ensure the indices are within valid range
        if (!selectedItemGrid.BoundaryCheck(positionOnGrid.x, positionOnGrid.y, 1, 1))
        {
            inventoryHighlight.Show(false);
            return;
        }

        if (oldPosition == positionOnGrid)
        {
            return;
        }

        oldPosition = positionOnGrid;

        if (selectedItem == null)
        {
            itemToHighlight = selectedItemGrid.GetItem(positionOnGrid.x, positionOnGrid.y);

            if (itemToHighlight != null)
            {
                inventoryHighlight.Show(true);
                inventoryHighlight.SetSize(itemToHighlight);
                inventoryHighlight.SetPosition(selectedItemGrid, itemToHighlight);
            }
            else
            {
                inventoryHighlight.Show(false);
            }
        }
        else
        {
            inventoryHighlight.Show(selectedItemGrid.BoundaryCheck(positionOnGrid.x, positionOnGrid.y, selectedItem.WIDTH, selectedItem.HEIGHT));
            inventoryHighlight.SetSize(selectedItem);
            inventoryHighlight.SetPosition(selectedItemGrid, selectedItem, positionOnGrid.x, positionOnGrid.y);
        }
    }

    private void LeftMouseButtonPress()
    {
        Vector2Int tileGridPosition = GetGridPosition();

        if (selectedItem == null)
        {
            PickUpItem(tileGridPosition);
        }
        else
        {
            PlaceItem(tileGridPosition);
        }
    }

    public Vector2Int GetGridPosition()
    {
        Vector2 position = Input.mousePosition;

        if (selectedItem != null)
        {
            position.x -= (selectedItem.WIDTH - 1) * ItemGrid.tileSizeWidth / 2;
            position.y += (selectedItem.HEIGHT - 1) * ItemGrid.tileSizeHeight / 2;

        }
        return selectedItemGrid.GetGridPosition(position);
    }

    private void PlaceItem(Vector2Int tileGridPosition)
    {
        bool complete = selectedItemGrid.PlaceItem(selectedItem, tileGridPosition.x, tileGridPosition.y, ref overlapItem);
        if (complete)
        {
            selectedItem = null;
            if(overlapItem != null)
            {
                selectedItem = overlapItem;
                overlapItem = null;
                rectTransform = selectedItem.GetComponent<RectTransform>();
                rectTransform.SetAsLastSibling();
            }
        }
    }

    private void PickUpItem(Vector2Int tileGridPosition)
    {
        // Perform bounds checking to ensure the indices are within valid range
        if (selectedItemGrid.BoundaryCheck(tileGridPosition.x, tileGridPosition.y, 1, 1))
        {
            selectedItem = selectedItemGrid.PickUpItem(tileGridPosition.x, tileGridPosition.y);

            if (selectedItem != null)
            {
                rectTransform = selectedItem.GetComponent<RectTransform>();
                originalGridPosition = new Vector2Int(tileGridPosition.x, tileGridPosition.y);
            }
        }
    }

    private void ItemIconDrag()
    {
        if (selectedItem != null)
        {
            rectTransform.position = Input.mousePosition;
        }
    }
    public void InsertMatch3Item(ItemDataSO itemSO, Quality quality)
    {
        if (selectedItemGrid == null)
        {
            return;
        }

        // Create an InventoryItem and set its ItemDataSO
        CreateItem(itemSO);
        InventoryItem itemToInsert = selectedItem;
        selectedItem = null;
        itemToInsert.quality = quality; // Set the quality of the item

        // Insert the item into the grid
        InsertItem(itemToInsert);
    }

    public void CreateItem(ItemDataSO itemSO)
    {
        InventoryItem inventoryItem = Instantiate(itemPrefab).GetComponent<InventoryItem>();
        selectedItem = inventoryItem;

        rectTransform = inventoryItem.GetComponent<RectTransform>();
        rectTransform.SetParent(canvasTransform);
        rectTransform.SetAsLastSibling();

        
        inventoryItem.Set(itemSO);
    }

    

}
