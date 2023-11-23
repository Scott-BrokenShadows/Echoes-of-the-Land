using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public CameraSwitcher cameras;
    public Audiomanager audiomanager;
    public InventoryController inventory;
    public Timer timer;
    public TurnChecker turnChecker;
    public Button endGameButton;
    public SceneSwapper swapper;
    public string currentScene;
    

    public ItemDataSO[] itemData;

    public GameObject endPanel;
    public int item1Quality;
    public int item2Quality;
    public int item3Quality;
    public int item4Quality;
    public TextMeshProUGUI item1Text;
    public TextMeshProUGUI item2Text;
    public TextMeshProUGUI item3Text;
    public TextMeshProUGUI item4Text;

    // Start is called before the first frame update
    void Start()
    {
        cameras = FindObjectOfType<CameraSwitcher>();
        swapper = FindObjectOfType<SceneSwapper>();
        audiomanager = FindObjectOfType<Audiomanager>();
        inventory = FindObjectOfType<InventoryController>();
        timer = FindObjectOfType<Timer>();
        endPanel.SetActive(false);
        endGameButton.enabled = false;
        currentScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (turnChecker.remainingTurns <= 0)
        {
            endPanel.SetActive(true);
            StartCoroutine(WaitForFalling());
        }
    }

    //private void SetValues()
    //{
    //    SetItem1();
    //    SetItem2();
    //    SetItem3();
    //    SetItem4();
    //}

    private void SetItem1()
    {
        if (turnChecker.item1Value < 12)
        {
            item1Quality = 1;
            item1Text.text = "Failed to Refine";
        }
        if (turnChecker.item1Value >= 12 && turnChecker.item1Value < 25)
        {
            item1Quality = 2;
            item1Text.text = "Normal Quality";
        }
        if (turnChecker.item1Value >= 25 && turnChecker.item1Value < 40)
        {
            item1Quality = 3;
            item1Text.text = "Good Quality";
        }
        if (turnChecker.item1Value >= 40)
        {
            item1Quality = 4;
            item1Text.text = "Great Quality";
        }
    }

    private void SetItem2()
    {
        if (turnChecker.item2Value < 12)
        {
            item2Quality = 1;
            item2Text.text = "Failed to Refine";
        }
        if (turnChecker.item2Value >= 12 && turnChecker.item2Value < 25)
        {
            item2Quality = 2;
            item2Text.text = "Normal Quality";
        }
        if (turnChecker.item2Value >= 25 && turnChecker.item2Value < 40)
        {
            item2Quality = 3;
            item2Text.text = "Good Quality";
        }
        if (turnChecker.item2Value >= 40)
        {
            item2Quality = 4;
            item2Text.text = "Great Quality";
        }
    }

    private void SetItem3()
    {
        if (turnChecker.item3Value < 12)
        {
            item3Quality = 1;
            item3Text.text = "Failed to Refine";
        }
        if (turnChecker.item3Value >= 12 && turnChecker.item3Value < 25)
        {
            item3Quality = 2;
            item3Text.text = "Normal Quality";
        }
        if (turnChecker.item3Value >= 25 && turnChecker.item3Value < 40)
        {
            item3Quality = 3;
            item3Text.text = "Good Quality";
        }
        if (turnChecker.item3Value >= 40)
        {
            item3Quality = 4;
            item3Text.text = "Great Quality";
        }
    }

    private void SetItem4()
    {
        if (turnChecker.item4Value < 12)
        {
            item4Quality = 1;
            item4Text.text = "Failed to Refine";
        }
        if (turnChecker.item4Value >= 12 && turnChecker.item4Value < 25)
        {
            item4Quality = 2;
            item4Text.text = "Normal Quality";
        }
        if (turnChecker.item4Value >= 25 && turnChecker.item4Value < 40)
        {
            item4Quality = 3;
            item4Text.text = "Good Quality";
        }
        if (turnChecker.item4Value >= 40)
        {
            item4Quality = 4;
            item4Text.text = "Great Quality";
        }
        
    }

    public void FinaliseGame()
    {
        SendItem1();
        SendItem2();
        SendItem3();
        SendItem4();
        StartCoroutine(SwapScene());
        timer.AdvanceTime();
        cameras.SwitchCanvasOrder(3);
        cameras.SwitchToCamera(3);
        audiomanager.CrossfadeMusic(1);
        
    }

    private void SendItem1()
    {
        ItemDataSO item = itemData[0];
        if (item1Quality == 1) 
        {
            return; 
        }
        if (item1Quality == 2)
        {
            inventory.InsertMatch3Item(item, Quality.Normal);
        }
        if (item1Quality == 3)
        {
            inventory.InsertMatch3Item(item, Quality.Good);
        }
        if (item1Quality == 4)
        {
            inventory.InsertMatch3Item(item, Quality.Great);
        }
    }

    private void SendItem2()
    {
        ItemDataSO item = itemData[1];
        if (item2Quality == 1)
        {
            return;
        }
        if (item2Quality == 2)
        {
            inventory.InsertMatch3Item(item, Quality.Normal);
        }
        if (item2Quality == 3)
        {
            inventory.InsertMatch3Item(item, Quality.Good);
        }
        if (item2Quality == 4)
        {
            inventory.InsertMatch3Item(item, Quality.Great);
        }
    }

    private void SendItem3()
    {
        ItemDataSO item = itemData[2];
        if (item3Quality == 1)
        {
            return;
        }
        if (item3Quality == 2)
        {
            inventory.InsertMatch3Item(item, Quality.Normal);
        }
        if (item3Quality == 3)
        {
            inventory.InsertMatch3Item(item, Quality.Good);
        }
        if (item3Quality == 4)
        {
            inventory.InsertMatch3Item(item, Quality.Great);
        }
    }

    private void SendItem4()
    {
        ItemDataSO item = itemData[3];
        if (item4Quality == 1)
        {
            return;
        }
        if (item4Quality == 2)
        {
            inventory.InsertMatch3Item(item, Quality.Normal);
        }
        if (item4Quality == 3)
        {
            inventory.InsertMatch3Item(item, Quality.Good);
        }
        if (item4Quality == 4)
        {
            inventory.InsertMatch3Item(item, Quality.Great);
        }
    }

    public IEnumerator WaitForFalling()
    {
        yield return new WaitForSecondsRealtime(4f);

        //SetValues();
        SetItem1();
        yield return new WaitForSecondsRealtime(0.75f);
        SetItem2();
        yield return new WaitForSecondsRealtime(0.75f);
        SetItem3();
        yield return new WaitForSecondsRealtime(0.75f);
        SetItem4();
        yield return new WaitForSecondsRealtime(0.75f);
        endGameButton.enabled = true;
    }

    public IEnumerator SwapScene()
    {
        yield return new WaitForSeconds(1f);

        swapper.LoadUnloadScene(currentScene);
    }

    
}
