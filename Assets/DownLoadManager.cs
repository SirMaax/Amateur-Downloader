using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownLoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Downloading = false;
    public float timeForDownload;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDownload(bool real)
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
            StartCoroutine(TimeTillDownloadComplete());
            //StartTimeTillCompletion
        }
    }
    private IEnumerator TimeTillDownloadComplete()
    {
        //Animation here
        yield return new WaitForSeconds(timeForDownload);
        Finish();
    }

    private void Finish()
    {
        
    }
}
