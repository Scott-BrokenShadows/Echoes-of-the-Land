using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GuildFunds : MonoBehaviour
{
    public int guildFundsValue;
    public TextMeshProUGUI guildFundText;
    // Start is called before the first frame update
    void Start()
    {
        //set to high number for initial alpha testing
        guildFundsValue = 1500;
        guildFundText.text = guildFundsValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (guildFundsValue <= -200)
        {
            SceneManager.LoadScene("Credits");
        }
    }

    public void SpendGold(int amount)
    {
        guildFundsValue = guildFundsValue - amount;
        guildFundText.text = guildFundsValue.ToString();
    }

    public void GainGold(int amount)
    {
        guildFundsValue = guildFundsValue + amount;
        guildFundText.text = guildFundsValue.ToString();
    }
}
