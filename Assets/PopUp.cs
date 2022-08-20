using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PopUp : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("CloseArea")] public Vector3 popUpSize;
    
    [Range(0, 1)] public int location;

    [Header("CloseTime")] public bool hasCloseTime;
    [SerializeField] private float timeTillClose;
    [SerializeField] private float sizeReducer;

    [Header("TypeofPopUp")] 
    public int typeOfPopUp;
    public int size;
    [SerializeField] private Vector2[] sizes;
    [SerializeField] private Vector2[] offsets;
    [SerializeField] private Vector2[] colliderSize;
    public float zachsis;
    
    [Header("Privat Stuff")] 
    private bool closing = false;
    public Vector2 offset;
    private bool canDelete;

    [Header("Refs")] 
    public PopUpSpawner spawner;
    
    void Start()
    {
        closing = false;
        SetAnimation();
        SetSize();
        SetChildren();
    }

    private void Update()
    {
        // if (closing)
        // {
        //     Vector2 scale = transform.localScale;
        //     if (scale.x <= 0 || scale.y <= 0)
        //     {
        //         GetComponent<SpriteRenderer>().enabled = false;
        //         return;
        //     }
        //     scale.x = scale.y -= sizeReducer;
        //     transform.localScale = scale;
        // }
        
    }

    private void OnMouseDown()
    {
        //CHeck Mouse Pos and depends where it is do sthm
        transform.GetChild(0).GetComponent<Mover>().OnMouseUp();
    }

    public void DestroyObject()
    {
        closing = true;
        Debug.Log("clicked on popup");
        if (!hasCloseTime) RemoveObject();
        else StartCoroutine(Destroy());
    }
    


    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(timeTillClose);
        RemoveObject();
    }



    private void RemoveObject()
    {
        spawner.RemovePopUp(gameObject);

    }

    private void SetAnimation()
    {
        if(typeOfPopUp == 0) GetComponent<Animator>().Play("Burger");
        if(typeOfPopUp == 1) GetComponent<Animator>().Play("cat");

    }

    private void SetSize()
    {
        transform.localScale = new Vector3(4.19f, 4.19f, 4.19f);
        transform.GetChild(0).GetComponent<Mover>().setOffset = offsets[typeOfPopUp];      
        transform.GetChild(0).GetComponent<Mover>().colliderSize = colliderSize[typeOfPopUp];
        transform.GetChild(0).GetComponent<Mover>().size = sizes[typeOfPopUp];
    }

    public void TriggerEffect(int effect)
    {
        Debug.Log("effect triggered");
    }

    private void SetChildren()
    {
        int r = Random.Range(1, 6);
        transform.GetChild(r).GetComponent<BoxScript>().effect = 0;
        int r2 = Random.Range(1, 6);
        if (r2 != r) r = r2;
        else if (r < 6) r = 6;
        else r = 5;
        transform.GetChild(r).GetComponent<BoxScript>().effect = 1;

        transform.GetChild(1).GetComponent<BoxScript>().popUp = this;
        transform.GetChild(2).GetComponent<BoxScript>().popUp = this;
        transform.GetChild(3).GetComponent<BoxScript>().popUp = this;
        transform.GetChild(4).GetComponent<BoxScript>().popUp = this;
        transform.GetChild(5).GetComponent<BoxScript>().popUp = this;
        transform.GetChild(6).GetComponent<BoxScript>().popUp = this;
        transform.GetChild(0).GetComponent<Mover>().zAchsis = (zachsis + 0.01f);
        transform.GetChild(1).GetComponent<BoxScript>().zAchsis = zachsis;
        transform.GetChild(2).GetComponent<BoxScript>().zAchsis = zachsis;
        transform.GetChild(3).GetComponent<BoxScript>().zAchsis = zachsis;
        transform.GetChild(4).GetComponent<BoxScript>().zAchsis = zachsis;
        transform.GetChild(5).GetComponent<BoxScript>().zAchsis = zachsis;
        transform.GetChild(6).GetComponent<BoxScript>().zAchsis = zachsis;
    }
    
}
