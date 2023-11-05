using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    InventoryController inventoryController;
    ItemGrid itemGrid;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Hovering Grid");
        //inventoryController.selectedItemGrid = itemGrid;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exited Grid");
        //inventoryController.selectedItemGrid = null;
    }

    private void Start()
    {
        inventoryController = FindObjectOfType(typeof(InventoryController)) as InventoryController;
        itemGrid = GetComponent<ItemGrid>();
    }
    
}
