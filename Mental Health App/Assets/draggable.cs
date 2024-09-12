using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android.LowLevel;

public class draggable : MonoBehaviour
{
    bool drag;

    private void OnMouseDown()
    {
        drag = true;
        print("Mouse Down");
    }

    private void OnMouseUp()
    {
        drag = false;
        print("Mouse up");
    }

    private void Update()
    {
        if (drag)
        {
            Vector2 MousePos = Camera.current.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.position = MousePos;
        }
    }
}
