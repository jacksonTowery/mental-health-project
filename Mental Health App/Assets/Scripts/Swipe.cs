using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 endPos;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startPos = Input.GetTouch(0).position;
            Debug.Log("BeganTouch");
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endPos = Input.GetTouch(0).position;
            Debug.Log("EndedTouch");

            //Swipe left
            if (endPos.x < startPos.x)
            {
                SLeft();
            }

            //Swipe Right
            if (endPos.x > startPos.x)
            {
                SRight();
            }

            //Swipe Down
            if (endPos.y < startPos.y)
            {
                SDown();
            }

            //Swipe Up
            if (endPos.y > startPos.y)
            {
                SUp();
            }
        }
    }

    private void SLeft()
    {
        Debug.Log("Swiped Left");
    }
    private void SRight()
    {
        Debug.Log("Swiped Right");
    }
    private void SDown()
    {
        Debug.Log("Swiped Down");
    }
    private void SUp()
    {
        Debug.Log("Swiped Up");
    }
}
