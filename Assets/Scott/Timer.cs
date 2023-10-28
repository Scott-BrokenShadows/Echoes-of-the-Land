using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int turn;
    public int currentTurn;
    public int days;

    public Sprite[] turnSprites;
    public Image turnImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
        turn = 0;
        currentTurn = 0;
        days = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (turn >= 11)
        {
            days++;
            turn = 0;
        }

        if (currentTurn != turn)
        {
            currentTurn = turn;
            turnImage.sprite = turnSprites[currentTurn];
        }

        
    }

    public void AdvanceTime()
    {
        turn++;
    }
}
