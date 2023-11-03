using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    private const float maxProgress = 10f;
    public float progress;
    private Image progressBar;

    // Start is called before the first frame update
    void Start()
    {
        progressBar = GetComponent<Image>();


    }

    // Update is called once per frame
    void Update()
    {
        progressBar.fillAmount = progress / maxProgress;
    }
}
