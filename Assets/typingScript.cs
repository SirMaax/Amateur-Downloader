
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typingScript : MonoBehaviour
{


    [SerializeField] int steps; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(typeText());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator typeText(){
        for( int i = 0; i < steps; i++){
            transform.position+= new Vector3(0.24f, 0, 0);
            transform.localScale-= new Vector3(0.24f, 0, 0);
            yield return new WaitForSeconds( 0.05f );
        }
        transform.parent.GetComponent<CutsceneScript>().InitPhase2();
        Destroy(gameObject);
    }


}
