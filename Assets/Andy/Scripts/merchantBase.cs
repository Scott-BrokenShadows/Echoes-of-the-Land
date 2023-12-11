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
    public Timer timer;
    public int turnCountHere;
    public int turnCountNotHere;
    private int turnCount;

    //public GuildFunds guildFunds;
    public Button merchantButton;

    public bool isHere;

    //public InventoryController inventory;

    // Start is called before the first frame update
    void Start()
    {
        isHere = true; //merchants are here at the beginning of the game

        timer.OnTurnUpdate += HandleTurnUpdate; //"subscribing" to the event?
    }

    // Update is called once per frame
    void Update()
    {
        //counting how many turns the merchant is here and how many turns the merchant is not here
        if (turnCount <= 0 && isHere) // if the merchant is here and the counter is 0, then they have moved away and turncount for when they aren't here is added'
        {
            turnCount = turnCountNotHere;
            isHere = false;
        }
        else if (turnCount <= 0 && !isHere) //ifn the merchant is not here and the counter is 0, then the merchant is here and turncount for their stay is added
        {
            turnCount = turnCountHere;
            isHere = true;
        }

        //isHere is a bool for this switch statement
        switch (isHere) 
        {
            case true:
            merchantButton.gameObject.SetActive(true); //if merchant is here, then turn button on
            break;
            case false:
            merchantButton.gameObject.SetActive(false); //if merchant is not here, then turn button off
            break;
        }
    }

    private void HandleTurnUpdate()
    {
        turnCount--; //when time passes, reduce turncounter by one
    }
}
