using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

    [Header("Info")] 
    public int effect = -1;
    public float zAchsis;

    [Header("Refs")] 
    public PopUp popUp;
    private SoundManager sound;

    //art is called before the first frame update
    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();

        zAchsis = +0.01f;
        // gameObject.transform.position = new Vector3(0, 0, -zAchsis);
    }

    public void Update()

    {
        // Vector3 temp = popUp.transform.position;
        // temp.z = zAchsis;
        // transform.position = temp;
    }

    public void OnMouseDown()
    {
        if (effect == 0)
        {
            popUp.DestroyObject();
            return;
        }else if (effect == 1)
        {
            popUp.TriggerEffect(1);
        }else if (effect == -1)
        {
            sound.Play(8);
        }
    }
}
