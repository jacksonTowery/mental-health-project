using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.Android.LowLevel;
using UnityEngine.SceneManagement;

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
            Vector3 MousePos = Camera.current.ScreenToViewportPoint(5*Input.mousePosition);
            transform.localPosition = MousePos - new Vector3(2,4,0);
        }
    }
}
