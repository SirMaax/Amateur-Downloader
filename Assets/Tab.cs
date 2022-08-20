using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour
{
    [Header("Tab")] public int tab;

    [Header("Refs")] public GameObject flowController;
    public void OnMouseDown()
    {
        if (tab != GameFlowController.CURRENTAB)
        {
            flowController.GetComponent<GameFlowController>().SwitchToTab(tab);
        }
    }
}
