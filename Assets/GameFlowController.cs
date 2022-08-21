using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowController : MonoBehaviour
{
    public static int CURRENTAB;

    [Header("Refs")] public GameObject popUpObject;
    public GameObject buttons;
    public GameObject guide;
    private PopUpSpawner popUpSpawner;
    

    public GameObject[] tabs; 
    public static bool GameOver = false;
    public static bool NextLevel;
    public static int currentLevel;
    private SoundManager sound;
    
    // Start is called before the first frame update
    void Start()
    {
        popUpSpawner = popUpObject.GetComponent<PopUpSpawner>();
        sound = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver) TriggerGameOver();
        if (NextLevel) TriggerNextLevel();

    }

    public void SwitchToTab(int tab)
    {
        if (tab == 0)
        {
            //deavtive all Button
            tabs[2].SetActive(false);
            //Activate Guide
            tabs[3].SetActive(true);

        }
        else
        {
            tabs[2].SetActive(true);
            //Activate Guide
            tabs[3].SetActive(false);
 

            //AdtiveButtonk
            //deacitve Guide
        }
        ArrayList[] list = popUpSpawner.GetTabObject();
        foreach (GameObject ele  in list[CURRENTAB])
        {
            ele.SetActive(false);
        }
        foreach (GameObject ele  in list[tab])
        {
            ele.SetActive(true);
            ele.GetComponent<PopUp>().SetAnimation();
        }
        tabs[CURRENTAB].SetActive(false);
        tabs[tab].SetActive(true);
        
        CURRENTAB = tab;
    }

    private void TriggerGameOver()
    {
        sound.Play(5);
    }

    private void TriggerNextLevel()
    {
        
    }
}
