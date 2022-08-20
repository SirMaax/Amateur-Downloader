using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("MouseInput")] public static Vector2 mousepos;

    [Header("States")]
    public static bool mouseInSide;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MouseInput(InputAction.CallbackContext context)
    {
        mousepos =  Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        if (mousepos.x < MapStats.MAPWIDTH && mousepos.x > -MapStats.MAPWIDTH &&
            mousepos.y < MapStats.MAPHEIGHT.x && mousepos.y > -MapStats.MAPHEIGHT.y) mouseInSide = true;
        else mouseInSide = false;
        
        Debug.Log(mousepos);
    }
}
