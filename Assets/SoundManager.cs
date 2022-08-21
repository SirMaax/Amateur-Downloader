using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioSource[] audio;
    void Start()
    {
        
    }



    public static void Play(int index)
    {
        audio[index].Play();
    }
}
