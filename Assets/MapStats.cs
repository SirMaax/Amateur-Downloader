using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStats : MonoBehaviour
{

    [Header("Map Widht")] 
    [SerializeField] public float mapWidth;
    [SerializeField] public Vector2 mapHeight;
    [SerializeField] public float mapWidth2;
    [SerializeField] public Vector2 mapHeight2;
    public static float MAPWIDTH;
    public static Vector2 MAPHEIGHT;
    public static float MAPWIDTH2;
    public static Vector2 MAPHEIGHT2;
    // Start is called before the first frame update
    void Start()
    {
        MAPWIDTH2 = mapWidth2;
        MAPHEIGHT2 = mapHeight2;
        MAPWIDTH = mapWidth;
        MAPHEIGHT = mapHeight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
