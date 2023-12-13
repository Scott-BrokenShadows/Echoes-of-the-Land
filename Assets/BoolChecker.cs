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
    }

    // Update is called once per frame
    void Update()
    {
        storyChecks.tutorial = flowChart.GetBooleanVariable("tutorial");
    }

    public void UnloadScene()
    {
        timer.AdvanceTime();
        swapper.LoadUnloadScene(currentScene);
    }
}
