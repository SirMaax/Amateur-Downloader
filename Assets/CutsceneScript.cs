using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{   

    public GameObject gameController;

    public GameObject[] cutsceneObjects;
    public Sprite[] browserSprites; 

    public Sprite[] searchTextSprites;

    public Sprite[] tabTextSprites;

    public Sprite[] popUpSprites;

    public GameObject bar;
    int iter;
    int vpnState;
    // Start is called before the first frame update
    void Start()
    {
        iter = 0;
        vpnState = 0;
        transform.GetChild(3).GetComponent<typingScript>().doStuff();
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void InitNext(){
        if(iter == 0){
            transform.GetChild(2).gameObject.SetActive(false);
            // Change to browser Results
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = browserSprites[1];
            // Makes the Links clickable
            transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
            // Enables the Title
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else{
            transform.GetChild(2).gameObject.SetActive(false);
            // Change to browser Results
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = browserSprites[2];
            // Makes the Links clickable
            transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
            // Enables the Title
            transform.GetChild(1).gameObject.SetActive(true);
        }

    }


    // Deactivates the Tab, starts the gameController after a Link on the results page has been clicked 
    public void InitFinishCutscene(){
        if(iter == 0){
            // Disables the Search Site
            transform.GetChild(0).gameObject.SetActive(false);
            // Enables the Game Controller
            gameController.SetActive(true);
            // Starts Level 0
            gameController.gameObject.GetComponent<GameFlowController>().AcitvateLevel0();

            // Prepare for Level 1 - n
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = browserSprites[0];
            transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = searchTextSprites[1];
        }
        else{
            // Disables the Search Site
            transform.GetChild(0).gameObject.SetActive(false);
            // Enables the Game Controller
            gameController.SetActive(true);
            // Starts Level 0
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = browserSprites[0];
            gameController.gameObject.GetComponent<GameFlowController>().AcitvateLevel1();
        }

    }

    // Plays a cutscen when the level has ended
    public void DisplayEndCutsceneObjects(){
        gameController.SetActive(false);
        Debug.Log("YOOOOO");
        if(iter == 0) {
            cutsceneObjects[0].gameObject.SetActive(true);
            bar.SetActive(true);

        }
        else {
            cutsceneObjects[1].gameObject.SetActive(true);
        }
        
    }

    public void EndCutscene(){
        if(iter == 0){
                cutsceneObjects[0].gameObject.SetActive(false);
                iter++;
                transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = tabTextSprites[1];
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(2).gameObject.SetActive(true);
                transform.GetChild(3).gameObject.SetActive(true);
                transform.GetChild(3).GetComponent<typingScript>().doStuff();
        }
        else{
            if(vpnState == 0){
                cutsceneObjects[1].GetComponent<SpriteRenderer>().sprite = popUpSprites[1];
                vpnState++;
            }
            else{
                cutsceneObjects[1].gameObject.SetActive(false);
                cutsceneObjects[1].GetComponent<SpriteRenderer>().sprite = popUpSprites[0];
                transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = tabTextSprites[1];
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(2).gameObject.SetActive(true);
                transform.GetChild(3).gameObject.SetActive(true);
                transform.GetChild(3).GetComponent<typingScript>().doStuff();
                vpnState = 0;
            }
        }
    }





}
