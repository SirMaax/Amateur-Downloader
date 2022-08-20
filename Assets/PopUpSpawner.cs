using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PopUpSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("SpawningArea")] [SerializeField]
    private float xDistance;

    [SerializeField] private Vector2 yDistance;

    [Header("SpawningSize")] [SerializeField]
    private float sizeX;

    [SerializeField] private float sizeY;

    [Header("SpawningTime")] public Vector2[] times;
    [SerializeField] private Vector2 intervalBetweenSpawning;
    public bool canSpawn = false;

    [Header("Tab")] private ArrayList[] tabObject;

    [Header("Refs")] public GameObject popupPrefab;
    public int[] test;
    [Header("Private Stuff")] private int layerInOrder = 1;

    private float zAchsis = 1;
    //-----------------------------------------------

    private void Start()
    {
        tabObject = new ArrayList[3];
        tabObject[0] = new ArrayList();
        tabObject[1] = new ArrayList();
        tabObject[2] = new ArrayList();
        // Test();
        StartCoroutine(SpawnCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        SpawnWhenPossible();
    }

    private IEnumerator SpawnCooldown()
    {
        float time = 0;
        int lastr = -1;
        float r = Random.value;
        for (int i = 0; i < times.Length; i++)
        {
            if (times[i].x >= r)
            {
                time = times[i].y;
                lastr = i;
                break;
            }
        }

        time += Random.Range(intervalBetweenSpawning.x, intervalBetweenSpawning.y);
        Debug.Log(time);
        yield return new WaitForSeconds(time);
        canSpawn = true;
    }

    private void SpawnWhenPossible()
    {
        if (!canSpawn) return;
        canSpawn = false;
        StartCoroutine(SpawnCooldown());

        Vector3 pos = Vector3.zero;
        pos.x = Random.Range(-xDistance + sizeX / 2, xDistance - sizeX / 2);
        pos.y = Random.Range(yDistance.x - sizeY / 2, yDistance.y + sizeY / 2);
        pos.z = -zAchsis;

        GameObject popUp = Instantiate(popupPrefab, pos, Quaternion.identity);
        popUp.GetComponent<PopUp>().spawner = this;
        
        SpriteRenderer sp = popUp.GetComponent<SpriteRenderer>();
        sp.color = Random.ColorHSV();
        
        sp.sortingOrder = layerInOrder;
        layerInOrder++;
        zAchsis += 0.0001f;

        tabObject[GameFlowController.CURRENTAB].Add(popUp);
    }

    public ArrayList[] GetTabObject()
    {
        return tabObject;
    }

    private void Test()
    {
        for (int j = 0; j < 10000; j++)
        {
            float time = 0;
            int lastr = -1;
            float r = Random.value;
            for (int i = 0; i < times.Length; i++)
            {
                if (times[i].x >= r)
                {
                    time = times[i].y;
                    lastr = i;
                    break;
                }
            }

            test[lastr]++;
        }


        // time += Random.Range(intervalBetweenSpawning.x, intervalBetweenSpawning.y);
    }
    /**
     * Remove Popop from list
     */
    public void RemovePopUp(GameObject go)
    {
        for (int i = 0; i < tabObject.Length; i++)
        {
            int index = tabObject[i].IndexOf(go);
            if (index != -1)
            {
                tabObject[i].RemoveAt(index);
                Destroy(go);
                return;
            }
        }
    }
}