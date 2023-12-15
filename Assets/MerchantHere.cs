using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantHere : MonoBehaviour
{
    public GameObject panel;
    public Button furMerch;
    public Button alchMerch;
    public bool panelOn;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((furMerch.gameObject.active == true || alchMerch.gameObject.active == true) && !panelOn)
        {
            panelOn = true;
            panel.SetActive(true);
        }

        if (furMerch.gameObject.active == false && alchMerch.gameObject.active == false && panelOn)
        {
            panelOn = false;
            panel.SetActive(false);
        }
    }
}
