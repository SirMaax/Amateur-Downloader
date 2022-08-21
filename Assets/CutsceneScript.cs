using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{   

    public GameObject[] levelObjects;
    public Sprite[] browserSprites; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void InitPhase2(){
        Destroy(transform.GetChild(2).gameObject);
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = browserSprites[1];
        transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void InitFinishCutscene(){
        transform.GetChild(0).gameObject.SetActive(false);
        foreach(GameObject g in levelObjects)
            g.SetActive(true);
        

    }

    public void EndLevel0(){
        foreach(GameObject g in levelObjects)
            g.SetActive(false);
        
    }
}
