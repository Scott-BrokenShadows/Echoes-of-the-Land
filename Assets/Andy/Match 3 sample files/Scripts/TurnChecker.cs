using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnChecker : MonoBehaviour
{
    public int initialTurns;
    [SerializeField] int remainingTurns;
    [SerializeField] int turnCheck;
    public int item1Value;
    public int item2Value;
    public int item3Value;
    public int item4Value;
    public int item5Value;
    [SerializeField] int check1;
    [SerializeField] int check2;
    [SerializeField] int check3;
    [SerializeField] int check4;
    [SerializeField] int check5;



    public TextMeshProUGUI turnText;
    public TextMeshProUGUI item1Text;
    public TextMeshProUGUI item2Text;
    public TextMeshProUGUI item3Text;
    public TextMeshProUGUI item4Text;
    public TextMeshProUGUI item5Text;
    // Start is called before the first frame update
    void Start()
    {
        remainingTurns = initialTurns;
        turnCheck = remainingTurns;
        item1Value = 0;
        check1 = 0;
        item2Value = 0;
        check2 = 0;
        item3Value = 0;
        check3 = 0;
        item4Value = 0;
        check4 = 0;
        item5Value = 0;
        check5 = 0;

        turnText.text = remainingTurns.ToString();
        item1Text.text = item1Value.ToString();
        item2Text.text = item2Value.ToString();
        item3Text.text = item3Value.ToString();
        item4Text.text = item4Value.ToString();
        item5Text.text = item5Value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTurns != turnCheck)
        {
            turnText.text = remainingTurns.ToString();
            turnCheck = remainingTurns;
        }

        if (item1Value != check1)
        {
            item1Text.text = item1Value.ToString();
            check1 = item1Value;
        }

        if (item2Value != check2)
        {
            item2Text.text = item2Value.ToString();
            check2 = item2Value;
        }

        if (item3Value != check3)
        {
            item3Text.text = item3Value.ToString();
            check3 = item3Value;
        }

        if (item4Value != check4)
        {
            item4Text.text = item4Value.ToString();
            check4 = item4Value;
        }

        if (item5Value != check5)
        {
            item5Text.text = item5Value.ToString();
            check5 = item5Value;
        }
    }

    public void TurnOver()
    {
        remainingTurns--;
    }

    public void Value1()
    {
        item1Value++;
    }

    public void Value2()
    {
        item2Value++;
    }

    public void Value3()
    {
        item3Value++;
    }

    public void Value4()
    {
        item4Value++;
    }

    public void Value5()
    {
        item5Value++;
    }
}
