/*
 System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    private InputManager inputManager;

    private void Awake()
    {
        inputmanager = inputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position)
    {

    }

    private void SwipeEnd()
    {

    }
}
*/