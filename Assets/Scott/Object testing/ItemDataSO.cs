using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Grid Shape", menuName = "Inventory System/Item Data")]
public class ItemDataSO : ScriptableObject
{
    public int width = 1;
    public int height = 1;

    public Sprite itemIcon;

    //add further data here when needed
}
