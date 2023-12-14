using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class BoolChecker : MonoBehaviour
{
    public StoryChecker storyChecks;
    public Flowchart flowChart;
    public SceneSwapper swapper;
    public string currentScene;
    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        storyChecks = FindObjectOfType<StoryChecker>();
        swapper = FindObjectOfType<SceneSwapper>();
        currentScene = SceneManager.GetActiveScene().name;
        timer = FindObjectOfType<Timer>();

        if (storyChecks != null)
        {
            InitiliseChecker();
        }
    }

    public void InitiliseChecker()
    {
        flowChart.SetBooleanVariable("tutorial", storyChecks.tutorial);
        flowChart.SetBooleanVariable("tutorialCompleted", storyChecks.tutorialCompleted);
        flowChart.SetBooleanVariable("mQ1SO", storyChecks.mQ1SO);
        flowChart.SetBooleanVariable("mQ1SM", storyChecks.mQ1SM);
        flowChart.SetBooleanVariable("mQ1SY", storyChecks.mQ1SY);
        flowChart.SetBooleanVariable("mQ1C", storyChecks.mQ1C);
        flowChart.SetBooleanVariable("mQ2SO", storyChecks.mQ2SO);
        flowChart.SetBooleanVariable("mQ2SM", storyChecks.mQ2SM);
        flowChart.SetBooleanVariable("mQ2SY", storyChecks.mQ2SY);
        flowChart.SetBooleanVariable("mQ2C", storyChecks.mQ2C);
        flowChart.SetBooleanVariable("dStory1", storyChecks.dStory1);
        flowChart.SetBooleanVariable("dStory1C", storyChecks.dStory1C);
        flowChart.SetBooleanVariable("lStory1", storyChecks.lStory1);
        flowChart.SetBooleanVariable("lStory1C", storyChecks.lStory1C);
        flowChart.SetBooleanVariable("sStory1", storyChecks.sStory1);
        flowChart.SetBooleanVariable("sStory1C", storyChecks.sStory1C);
    }

    // Update is called once per frame
    void Update()
    {
        storyChecks.mQ1C = flowChart.GetBooleanVariable("mQ1C");
        storyChecks.mQ2C = flowChart.GetBooleanVariable("mQ2C");
        storyChecks.dStory1C = flowChart.GetBooleanVariable("dStory1C");
        storyChecks.lStory1C = flowChart.GetBooleanVariable("lStory1C");
        storyChecks.sStory1C = flowChart.GetBooleanVariable("sStory1C");
        storyChecks.tutorial = flowChart.GetBooleanVariable("tutorial");
    }

    public void UnloadScene()
    {
        timer.AdvanceTime();
        swapper.LoadUnloadScene(currentScene);
    }

    public void AddQuest(string questName)
    {
        storyChecks.AddQuest(questName);
    }
}
