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
    public GameObject CutsceneScript;

    public GameObject[] allButtons;
    public GameObject[] allGuides;
    public GameObject progresBar;
    public GameObject gameover;
    [Header("Level1")] public GameObject tabCollider;
    // Start is called before the first frame update

    [Header("Level2")] 
    public GameObject Level2;
    public Sprite teil2;
    void Start()
    {
        popUpSpawner = popUpObject.GetComponent<PopUpSpawner>();
        sound = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
        currentLevel = 0;
        popUpSpawner.StartIn5();
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
            buttons.SetActive(true);
            //Activate Guide
            guide.SetActive(false);
        }
        else
        {
            
            buttons.SetActive(false);
            //Activate Guide
            guide.SetActive(true);


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
        StopAll();
        sound.enabled = false;
        gameover.SetActive(true);
    }

    private void TriggerNextLevel()
    {
        NextLevel = false;
        Debug.Log("next level");
        //Deactivate all stuff 
        CutsceneScript.GetComponent<CutsceneScript>().DisplayEndCutsceneObjects();
        StopAll();
        
    }

    public void AcitvateLevel0()
    {
        tabCollider.SetActive(true);
        buttons.SetActive(true);
    }

    public void StartNextLevel()
    {
        currentLevel++;
        buttons = allButtons[1];
        guide = allGuides[1];
        buttons.SetActive(true);
        guide.SetActive(false);
        //Acitvate Buttons
        //Deactive Guide but load next guide
        popUpSpawner.GetComponent<PopUpSpawner>().Continue();
        progresBar.transform.GetChild(0).gameObject.GetComponent<ProgressBar>().Continue();
        CURRENTAB = 0;

    }

    private void StopAll()
    {
        buttons.SetActive(false);
        guide.SetActive(false);
        popUpSpawner.GetComponent<PopUpSpawner>().Stop();
        progresBar.transform.GetChild(0).gameObject.GetComponent<ProgressBar>().Stop();
        //Progressbar back
    }

    public void AcitvateLevel1()
    {
        tabCollider.SetActive(true);
        StartNextLevel();
    }
}
