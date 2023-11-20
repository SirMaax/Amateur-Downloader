
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typingScript : MonoBehaviour
{

    private Vector3 startPos;
    private Vector3 startScale;
    [SerializeField] int steps; 
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startScale = transform.localScale;
        GameObject.FindWithTag("Audio").GetComponent<SoundManager>().Play(1);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void doStuff(){
        StartCoroutine(typeTextintro());
    }

    public IEnumerator typeTextintro(){
        for( int i = 0; i < steps; i++){
            transform.position+= new Vector3(0.24f, 0, 0);
            transform.localScale-= new Vector3(0.24f, 0, 0);
            yield return new WaitForSeconds( 0.05f );
        }
        transform.parent.GetComponent<CutsceneScript>().InitNext();
        GameObject.FindWithTag("Audio").GetComponent<SoundManager>().audio[1].Stop();

        transform.position = startPos;
        transform.localScale = startScale;
        gameObject.SetActive(false);
    }



}
