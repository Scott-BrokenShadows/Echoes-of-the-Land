using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
    Plant,
    Rock,
    Animal,
    Item1,
    Item2,
    Item3,
    Item4
}

public enum Quality
{
    Normal,
    Good,
    Great
}

[CreateAssetMenu]
public class ItemDataSO : ScriptableObject
{
    public int width = 1;
    public int height = 1;

    public Sprite itemIcon;
    public ItemTypes itemType;
    

    //add further data here when needed
}
