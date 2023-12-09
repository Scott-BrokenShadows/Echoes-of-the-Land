using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class merchantBase : MonoBehaviour
{
    public string merchantName;
    public string merchantNickname;

    public float meatMod;
    public float furMod;
    public float eyeMod;
    public float boneMod;
    public float rubyMod;
    public float amethystMod;
    public float sapphireMod;
    public float topazMod;
    public float flowerMod;
    public float fruitMod;
    public float fibreMod;
    public float leafMod;

    [Range(1, 100)]
    public int trust;

    public GuildFunds guildFunds;
    public Button merchantButton;

    public bool isHere;

    //add function to update/advance time when interacting with the sell script??
    //something similar to below
    //timer.OnTurnUpdate += HandleTurnUpdate;
    //merchanttime--

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
