using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    
    
    
    [Header("Dragging")] 
    public Vector2 offset;

    [Header("refs")] private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = transform.parent.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseDrag()
    {
        sp.sortingOrder = PopUpSpawner.layerInOrder + 10;
        
        if (offset == Vector2.zero)
        {
            Vector2 temp = transform.parent.position;
            offset = InputManager.mousepos - temp;
        }
        
        transform.parent.position = InputManager.mousepos - offset;
        ClampBoxInside();
    }
    
    private void OnMouseUp()
    {
        offset = Vector2.zero;
        sp.sortingOrder = PopUpSpawner.layerInOrder;
    }
    private void ClampBoxInside()
    {
        var size = GetComponent<BoxCollider2D>().size;
        var temp = transform.parent.position;
        temp.x = Mathf.Clamp(temp.x, -MapStats.MAPWIDTH + size.x / 2, MapStats.MAPWIDTH - size.x / 2);
        temp.y = Mathf.Clamp(temp.y, -MapStats.MAPHEIGHT.y + size.y / 2, MapStats.MAPHEIGHT.x - size.y / 2);
        temp.z = 1;
        transform.parent.position = temp;
    }
}
