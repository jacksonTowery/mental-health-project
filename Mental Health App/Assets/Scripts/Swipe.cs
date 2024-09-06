using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class Swipe : MonoBehaviour
{
    public Sprite ArrowImage;
    public List<Sprite> Arrows;
    public int ArrowID;

    private Vector2 startPos;
    private Vector2 endPos;
    private int deadzone = 10;

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
            if (endPos.x < startPos.x-deadzone)
            {
                SLeft();
            }

            //Swipe Right
            if (endPos.x > startPos.x+deadzone)
            {
                SRight();
            }

            //Swipe Down
            if (endPos.y > startPos.y+deadzone)
            {
                SDown();
            }

            //Swipe Up
            if (endPos.y < startPos.y-deadzone)
            {
                SUp();
            }
        }
    }

    private void SLeft()
    {
        ArrowID = 0;
        ArrowImage.texture.Equals(Arrows[ArrowID].texture);
        Debug.Log("Swiped Left");
    }
    private void SRight()
    {
        ArrowID = 1;
        Debug.Log("Swiped Right");
    }
    private void SDown()
    {
        ArrowID = 2;
        Debug.Log("Swiped Down");
    }
    private void SUp()
    {
        ArrowID = 3;
        Debug.Log("Swiped Up");
    }
}
