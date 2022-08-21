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
    

    int iter;
    // Start is called before the first frame update
    void Start()
    {
        iter = 0;
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
            transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = tabTextSprites[1];
            transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = searchTextSprites[1];
            iter++;
        }
        else{
            
        }

    }

    // Plays a cutscen when the level has ended
    public void EndLevel(int index){
        gameController.SetActive(false);
        if(index == 0) {
            cutsceneObjects[0].gameObject.SetActive(true);
        }
        else {
            DisplayEndCutsceneElement(1);
        }
        
    }


    // Plays the Cutscene for the given level
    public void InitStartCutsceneLevel(){
        
    }

    public void DisplayEndCutsceneElement(int e){
        if(e < cutsceneObjects.Length-1 ){
            cutsceneObjects[e].gameObject.SetActive(false);
            cutsceneObjects[e+1].gameObject.SetActive(true);
        }
        else{

        }
    }



}
