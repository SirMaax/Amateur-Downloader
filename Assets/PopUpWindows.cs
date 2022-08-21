using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PopUpWindows : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnMouseDown()
    {
        Destroy(this);
    }
}
