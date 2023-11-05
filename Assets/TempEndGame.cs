using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEndGame : MonoBehaviour
{
    public string urlOfForm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        Debug.Log("Quit Button Pressed");
        Application.Quit();
    }

    public void GoogleForm()
    {
        Application.OpenURL(urlOfForm);
    }
}
