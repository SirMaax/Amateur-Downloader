using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("SpawningArea")] 
    [SerializeField] private float xDistance;
    [SerializeField] private Vector2 yDistance;

    [Header("SpawningSize")] 
    [SerializeField] private float sizeX;
    [SerializeField] private float sizeY;

    [Header("SpawningTime")] [SerializeField]
    private float intervalBetweenSpawning;
    public bool canSpawn = false;
    
    
    
    [Header("Refs")] public GameObject popupPrefab;
    
    [Header("Private Stuff")]
    private int layerInOrder = 1;

    private float zAchsis = 1;
    //-----------------------------------------------

    
    // Update is called once per frame
    void Update()
    {
        SpawnWhenPossible();
    }

    private IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(intervalBetweenSpawning);
        canSpawn = true;
    }

    private void SpawnWhenPossible()
    {
        if (!canSpawn) return;
        canSpawn = false;
        StartCoroutine(SpawnCooldown());
        
        Vector3 pos = Vector3.zero;
        pos.x = Random.Range(-xDistance + sizeX /2 , xDistance - sizeX /2);
        pos.y = Random.Range(yDistance.x - sizeY / 2, yDistance.y + sizeY /2 );
        pos.z = -zAchsis;
        
        GameObject popUp = Instantiate(popupPrefab, pos, Quaternion.identity);
        // popUp.GetComponent<PopUp>().
        SpriteRenderer sp = popUp.GetComponent<SpriteRenderer>();
        sp.color = Random.ColorHSV();
        sp.sortingOrder = layerInOrder;
        layerInOrder++;
        zAchsis += 0.0001f;
    }
}
