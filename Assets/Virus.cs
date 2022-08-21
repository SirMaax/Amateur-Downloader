using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    // Start is called before the first frame update
    private bool stop = false;
    public int nonEffect;
    public static int effect = 0;
    [Header("Blackscree")] 
    public GameObject blackScreen;
    public float blackScreenTime;

    [Header("Flicker")] 
    [SerializeField] private int amountOfFlicker;
    [SerializeField] private float timeBetweenFlicker;
    private int originalAmount;
    
    [Header("REFS")]
    private SoundManager sound;

    private void Start()
    {
        sound = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();

        effect = nonEffect;
        originalAmount = amountOfFlicker;
    }

    public void BlackScreen()
    {
        blackScreen.SetActive(true);
        StartCoroutine(BlackScreenDuration());
    }

    private IEnumerator BlackScreenDuration()
    {
        yield return new WaitForSeconds(blackScreenTime);
        blackScreen.SetActive(false);
    }

    private void Flicker()
    {
        blackScreen.SetActive(true);
        StartCoroutine(Flickering());
    }

    private IEnumerator Flickering()
    {
        
        yield return new WaitForSeconds(timeBetweenFlicker);
        bool temp = blackScreen.activeSelf;
        blackScreen.SetActive(!temp);
        amountOfFlicker--;
        if (amountOfFlicker <= 0)
        {
            amountOfFlicker = originalAmount;
            blackScreen.SetActive(false);
        }
        else
        {
        StartCoroutine(Flickering());
        }

    }
    
    private void Update()
    {
        if (effect == 1)
        {
            //Blackscreen
            effect = 0;
            sound.Play(6);
            BlackScreen();
        }
        else if (effect == 2)
        {
            effect = 0;
            sound.Play(6);
            //Flickering Screen
            Flicker();
        }
        else if (effect == 2)
        {
            effect = 0;
            sound.Play(6);
            //Flickering Screen
            //Audio Effect
        }
        
    }
}
