using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Dragging")] public Vector2 offset;
    public Vector2 size;
    public Vector2 setOffset;
    public Vector2 colliderSize;
    [Header("refs")] private SpriteRenderer sp;

    public int type = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    public void Update()
    {
        // Vector3 temp = popUp.transform.position;
        // temp.z = zAchsis;
        // transform.position = temp;
    }

    private void SetUp()
    {
        if (type == 0)
        {
            sp = transform.parent.GetComponent<SpriteRenderer>();
            BoxCollider2D col = GetComponent<BoxCollider2D>();
            col.size = colliderSize;
            col.offset = setOffset;
            // gameObject.transform.position = new Vector3(0, 0, -zAchsis);
        }
        else if(type == 1)
        {
            sp = transform.parent.GetComponent<SpriteRenderer>();

        }
    }

    // Update is called once per frame

    private void OnMouseDrag()
    {
        if (type == 2) return;
            sp.sortingOrder = PopUpSpawner.layerInOrder + 10;
 


        if (offset == Vector2.zero)
        {
            Vector2 temp = transform.parent.position;
            offset = InputManager.mousepos - temp;
        }

        Vector3 temp3 = InputManager.mousepos - offset;
        if (type == 0)
        {
            temp3.z = transform.parent.position.z;
            transform.parent.position = temp3;
        }
        else
        {
            temp3.z = -(PopUpSpawner.zAchsisWindows + 10);
            transform.parent.position = temp3;
        }
          
        ClampBoxInside();
    }

    private void OnMouseDown()
    {
        if (type == 2 || type == 3)
        {
    //TRIGGER FOR EXPIRE
            
        }
        else
        {
            return;
        }
    }

    public void OnMouseUp()
    {
        offset = Vector2.zero;
        PopUpSpawner.layerInOrder +=1;
        sp.sortingOrder = PopUpSpawner.layerInOrder;
        var temp = transform.parent.position;
        if (type == 0)
        {
            PopUpSpawner.zAchsis += 0.01f;
            temp.z = -PopUpSpawner.zAchsis;  
        }
        else
        {
            PopUpSpawner.zAchsisWindows += 0.01f;
            temp.z = -PopUpSpawner.zAchsisWindows;
            Vector3 temp2 = transform.position;
            temp2.z = -(PopUpSpawner.zAchsisWindows - 0.001f);
        }
        
        transform.parent.position = temp;
    }

    private void ClampBoxInside()
    {
        if (type == 0)
        {
            var z = transform.parent.position.z;
            var temp = transform.parent.position;
            temp.x = Mathf.Clamp(temp.x, -MapStats.MAPWIDTH + size.x / 2, MapStats.MAPWIDTH - size.x / 2);
            temp.y = Mathf.Clamp(temp.y, -MapStats.MAPHEIGHT.y + size.y / 2, MapStats.MAPHEIGHT.x - size.y / 2);
            temp.z = -z;
            transform.parent.position = temp;
        }
        else
        {
            var z = transform.parent.position.z;
            var temp = transform.parent.position;
            temp.x = Mathf.Clamp(temp.x, -MapStats.MAPWIDTH2 + size.x / 2, MapStats.MAPWIDTH2 - size.x / 2);
            temp.y = Mathf.Clamp(temp.y, -MapStats.MAPHEIGHT2.y + size.y / 2, MapStats.MAPHEIGHT2.x - size.y / 2);
            temp.z = z;
            transform.parent.position = temp;
        }
    }
}