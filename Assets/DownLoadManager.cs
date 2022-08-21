using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownLoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Downloading = false;
    public float timeForDownload;
    public bool currentDownload;
    public GameObject virus;
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
            currentDownload = real;
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
        Downloading = false;
        if (currentDownload)
        {
            GameFlowController.NextLevel = true;
            currentDownload = false;
        }
        else
        {
            //Random Effect open VIRUS OR PNG
            int r = Random.Range(0, 4);
            if (r == 1)
            {
                //Trigger Virus
                virus.GetComponent<Virus>().BlackScreen();
            }
            else if (r == 2)
            {
                //Trigger Virus
                virus.GetComponent<Virus>().Flicker();
            }
        }
    }
}
