using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownLoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Downloading = false;
    public float timeForDownload;
    public bool currentDownload;
    private Animator Animator;
    private SpriteRenderer sp;
    public GameObject virus;
    void Start()
    {
        Animator = GetComponent<Animator>();
        Animator.enabled = false;
        sp = GetComponent<SpriteRenderer>();
        sp.enabled = false;
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
            Animator.enabled = true;
            sp.enabled = true;

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
            else if (r == 3)
            {
                //Spawn POP UP WINDOWS CAT
            }
            else if (r == 0)
            {
                //Spawn POP UP WINDOWS NOUDLE
            }
        }
    }
}
