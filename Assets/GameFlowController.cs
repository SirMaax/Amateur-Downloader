using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowController : MonoBehaviour
{
    public static int CURRENTAB;

    [Header("Refs")] public GameObject popUpObject;
    private PopUpSpawner popUpSpawner;
    public GameObject[] tabs;
    // Start is called before the first frame update
    void Start()
    {
        popUpSpawner = popUpObject.GetComponent<PopUpSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToTab(int tab)
    {
        foreach (GameObject ele  in popUpSpawner.tabObject[CURRENTAB])
        {
            ele.SetActive(false);
        }
        foreach (GameObject ele  in popUpSpawner.tabObject[tab])
        {
            ele.SetActive(true);
        }
        tabs[CURRENTAB].SetActive(false);
        tabs[tab].SetActive(false);

        CURRENTAB = tab;
    }
}
