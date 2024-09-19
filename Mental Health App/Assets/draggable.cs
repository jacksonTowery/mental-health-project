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
            //Vector3 MousePos = Camera.current.ScreenToViewportPoint(3*Input.mousePosition);
            //transform.localPosition = MousePos - new Vector3(2,4,0);
            //Vector3 AbsPos = new Vector3(Mathf.Abs(transform.localPosition.x), Mathf.Abs(transform.localPosition.y), Mathf.Abs(transform.localPosition.z))*(-1);
            //transform.localPosition = MousePos - AbsPos;
            //transform.localPosition = AbsPos * (-1);
            Vector2 MousePos = Camera.current.ScreenToViewportPoint((float)2.5 * Input.mousePosition) - transform.localPosition;
            MousePos.x = MousePos.x - (float)1.75;
            MousePos.y = MousePos.y - (float)3.75;

            transform.Translate(MousePos);
        }
    }
}
