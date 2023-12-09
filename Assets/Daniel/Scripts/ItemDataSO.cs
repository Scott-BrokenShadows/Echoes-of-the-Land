using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
    Plant,
    Rock,
    Animal,
    Meat,
    Fur,
    Eyes,
    Bones,
    Ruby,
    Amethyst,
    Sapphire,
    Topaz,
    Flower,
    Fruit,
    Fibre,
    Leaves
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
    [TextArea]
    public string flavourText;
    public int baseValue;
    

    //add further data here when needed
}
