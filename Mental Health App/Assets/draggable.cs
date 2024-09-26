using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Android.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class draggable : MonoBehaviour
{
    bool drag;
    bool idle;
    Vector2 mouseLastPos;

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

    private bool MouseMoved()
    {
        if (Input.mousePosition == (Vector3)mouseLastPos)
        {
            print("Mouse moved");
            return false;
        }
        print("Mouse idle");
        return true;
    }

    private void Update()
    {
        mouseLastPos = Input.mousePosition;
        if (drag)
        {
            if (MouseMoved())
            {
                print("Mouse moving");
            }
            //Vector3 MousePos = Camera.current.ScreenToViewportPoint(3*Input.mousePosition);
            //transform.localPosition = MousePos - new Vector3(2,4,0);
            //Vector3 AbsPos = new Vector3(Mathf.Abs(transform.localPosition.x), Mathf.Abs(transform.localPosition.y), Mathf.Abs(transform.localPosition.z))*(-1);
            //transform.localPosition = MousePos - AbsPos;
            //transform.localPosition = AbsPos * (-1);

            
            Vector2 MousePos = Camera.current.ViewportToScreenPoint(Input.mousePosition);
            MousePos.x = MousePos.x / (float)(17280*4.5);
            MousePos.y = MousePos.y / (float)(30720 * 4.5);

            MousePos.x -= (float)17.375;
            MousePos.y -= (float)5.125;

            //MousePos.x = MousePos.x - 15;

            print("X: " + MousePos.x + "  Y: " + MousePos.y);
            //transform.Translate(MousePos);

            

            //Vector2 MousePos = Camera.current.ScreenToViewportPoint(Input.mousePosition);
            //MousePos.x = MousePos.x - (float)17.8125;

            transform.position = MousePos;
            mouseLastPos = MousePos;
        }
    }
}
