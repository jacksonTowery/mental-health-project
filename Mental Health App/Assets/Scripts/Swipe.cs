using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 endPos;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endPos = Input.GetTouch(0).position;

            //Swipe left
            if(endPos.x < startPos.x)
            {
                
            }

            if (endPos.x > startPos.x)
            {
                Debug.Log("Swiped right");
                Debug.DrawRay(startPos, endPos);
            }

        }
    }
}
