using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public int turn;
    public int currentTurn;
    public int totalDays;
    public int dayofWeek;
    public int weeks;

    public Sprite[] turnSprites;
    public Image turnImage;

    public TextMeshProUGUI dayOfWeekText;
    public TextMeshProUGUI weeksText;

    public delegate void TurnUpdatedEvent();
    public event TurnUpdatedEvent OnTurnUpdate;
    
    // Start is called before the first frame update
    void Start()
    {
        
        turn = 0;
        currentTurn = 0;
        totalDays = 1;
        dayofWeek = 1;
        weeks = 1;
        dayOfWeekText.text = dayofWeek.ToString();
        weeksText.text = weeks.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (turn >= 10)
        {
            totalDays++;
            dayofWeek++;
            turn = 0;
            StartCoroutine(UpdateDay());
        }

        if( dayofWeek > 7)
        {
            dayofWeek = 1;
            weeks++;
            weeksText.text = weeks.ToString();
        }

        if (currentTurn != turn)
        {
            currentTurn = turn;
            turnImage.sprite = turnSprites[currentTurn];
            OnTurnUpdate?.Invoke();
        }

        if(weeks == 4)
        {
            SceneManager.LoadScene("Credits");
        }
    }

    public void AdvanceTime()
    {
        turn++;
    }

    IEnumerator UpdateDay()
    {
        yield return new WaitForEndOfFrame();
        dayOfWeekText.text = dayofWeek.ToString();
    }
}
