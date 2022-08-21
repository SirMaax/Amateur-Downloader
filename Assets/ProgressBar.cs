using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [Header("Progess")] [SerializeField] private float timeBetweenMoves;
    [SerializeField] private float distance;
    [SerializeField] private float spriteGrow;
    [SerializeField] private float moveBarSpeed;
    [SerializeField] private float rightValue;
    [Header("Refs")] 
    public GameObject bar;

    public GameObject leftRand;
    // Start is called before the first frame update
    void Start()
    {
        Progress();
    }
    
    private void Progress()
    {
        if (transform.position.x >= rightValue)
        {
            GameFlowController.GameOver = true;
            return;
        }
        
        Vector3 pos = new Vector3(distance, 0, 0);
        transform.position += pos;
        
        //Move ProgressBar
        bar.transform.localScale += pos * spriteGrow;
        bar.transform.position += pos * moveBarSpeed;
        
        StartCoroutine(CooldDown());
    }

    private IEnumerator CooldDown()
    {
        yield return new WaitForSeconds(timeBetweenMoves);
        Progress();
    }
}
