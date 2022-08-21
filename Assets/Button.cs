using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Button : MonoBehaviour
{
    [Header("Info")] 
    public bool realButton;
    public String info;

    [Header("Downloading")] public static bool Downloading;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (Downloading)
        {
            //Play negative Sound
            return;
        }
        else
        {
            //CanDownload
            Downloading = true;
            //StartTimeTillCompletion
        }
        
    }
    
    // [CanBeNull] private IEnumerator TimeTillDownloadComplete
    
}
