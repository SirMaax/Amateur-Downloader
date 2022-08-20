using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("CloseArea")] public Vector3 popUpSize;
    [SerializeField] private Vector2 size;
    [Range(0, 1)] public int location;

    [Header("CloseTime")] public bool hasCloseTime;
    [SerializeField] private float timeTillClose;
    [SerializeField] private float sizeReducer;


    
    [Header("Privat Stuff")] 
    private bool closing = false;
    public Vector2 offset;
    private bool canDelete;

    [Header("Refs")] 
    public PopUpSpawner spawner;
    void Start()
    {
        SetSizeOfDelete();
        closing = false;
    }

    private void Update()
    {
        if (closing)
        {
            Vector2 scale = transform.localScale;
            if (scale.x <= 0 || scale.y <= 0)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                return;
            }
            scale.x = scale.y -= sizeReducer;
            transform.localScale = scale;
        }
        
    }

    private void OnMouseDown()
    {
        if (closing) return;
        Debug.Log("Mouse down");
        
        DestroyObject();
    }

    private void DestroyObject()
    {
        closing = true;
        Debug.Log("clicked on popup");
        if (!hasCloseTime) RemoveObject();
        else StartCoroutine(Destroy());
    }

    // private void OnMouseDrag()
    // {
    //     // if (!InputManager.mouseInSide)
    //     // {
    //     //     dragging = false;
    //     //     return;
    //     // }
    //     // //Drag it around
    //     dragging = true;
    //     Debug.Log("dragging true");
    //     if (offset == Vector2.zero)
    //     {
    //         Vector2 temp = transform.position;
    //         offset = InputManager.mousepos - temp;
    //     }
    //     
    //     transform.position = InputManager.mousepos - offset;
    //     ClampBoxInside();
    // }

    // private void OnMouseUp()
    // {
    //     dragging = false;
    //     offset = Vector2.zero;
    //     Debug.Log("Mouse up");
    //
    //     
    // }

    private void SetSizeOfDelete()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        float tempx = 0;
        float tempy = 0;
        if (location == 0) tempy = .5f;
        if (location == 1) tempy = tempx = .5f;
        
        collider.offset = new Vector2(tempx - size.x / 2, tempy - size.y / 2);
        collider.size = size;
        transform.localScale = popUpSize;

    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(timeTillClose);
        RemoveObject();
    }

    // private void ClampBoxInside()
    // {
    //     var temp = transform.position;
    //     temp.x = Mathf.Clamp(temp.x, -MapStats.MAPWIDTH + size.x / 2, MapStats.MAPWIDTH - size.x / 2);
    //     temp.y = Mathf.Clamp(temp.y, -MapStats.MAPHEIGHT.y + size.y / 2, MapStats.MAPHEIGHT.x - size.y / 2);
    //     transform.position = temp;
    // }

    // private IEnumerator TimeBeforeDrag()
    // {
    //     yield return new WaitForSeconds(0.1f);
    //     DestroyObject();
    //     
    // }

    private void RemoveObject()
    {
        spawner.RemovePopUp(gameObject);

    }
}
