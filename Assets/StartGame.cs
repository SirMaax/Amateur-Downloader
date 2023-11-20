using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ob;

    private void OnMouseDown()
    {
         ob.SetActive(true);
         Destroy(gameObject);
    }
}
