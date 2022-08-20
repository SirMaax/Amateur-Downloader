using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStats : MonoBehaviour
{

    [Header("Map Widht")] 
    [SerializeField] public float mapWidth;
    [SerializeField] public Vector2 mapHeight;

    public static float MAPWIDTH;
    public static Vector2 MAPHEIGHT;
    // Start is called before the first frame update
    void Start()
    {
        MAPWIDTH = mapWidth;
        MAPHEIGHT = mapHeight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
