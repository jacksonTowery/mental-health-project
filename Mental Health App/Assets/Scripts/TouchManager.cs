using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.EnhancedTouch;
//using static UnityEditor.Timeline.TimelinePlaybackControls;

[DefaultExecutionOrder(-1)]
public class TouchManager : MonoBehaviour
{

    public Vector2 startLoc;
    public Vector2 endLoc;

    [SerializeField]
    private GameObject player;

    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions["TouchPress"];
        touchPositionAction = playerInput.actions["TouchPosition"];
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        //float value = context.ReadValue<float>();
        //Debug.Log(value);

        Vector2 loc = touchPositionAction.ReadValue<Vector2>();
        if(Input.touchCount > 0)
        {
            startLoc = loc;
        }
        else
        {
            endLoc = loc;
        }
        Debug.Log("X pos: " + (int)loc.x + "  |  Y pos: " + (int)loc.y);
        Vector3 position = Camera.main.ScreenToWorldPoint(loc);
        position.z = player.transform.position.z;
        player.transform.position = position;


    }

    private int getStartYPos()
    {
        return (int)startLoc.y;
    }

    private int getStartXPos()
    {
        return (int)startLoc.x;
    }

    private int getEndYPos()
    {
        return (int)endLoc.y;
    }

    private int getEndXPos()
    {
        return (int)endLoc.x;
    }

    private void Update()
    {
        //if(touchPositionAction!=null)
            //Debug.Log("X pos: "+getXPos()+"  |  Y pos: "+getYPos());
    }
}


//    ///================\\\
//    |||OLD AND OUTDATED|||
//    \\\================///
/*
[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{




public delegate void StartTouchEvent(Vector2 position, float time);
public event StartTouchEvent OnStartTouch;
public delegate void EndTouchEvent(Vector2 position, float time);
public event EndTouchEvent OnEndTouch;

private TouchControls touchControls;

private void Awake()
{
    touchControls = new TouchControls();
}

private void OnEnable()
{
    touchControls.Enable();
    TouchSimulation.Enable();
    UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
}

private void OnDisable()
{
    touchControls.Disable();
    TouchSimulation.Disable();
    UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
}

private void Start()
{
    touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
    touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
}

private void StartTouch(InputAction.CallbackContext context)
{
    //Debug.Log("Touch Started " + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
    if (OnStartTouch != null)
        OnStartTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
}

private void EndTouch(InputAction.CallbackContext context)
{
    //Debug.Log("Touch Ended " + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
    if (OnEndTouch != null)
        OnEndTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
}

private void FingerDown(Finger finger)
{
    if (OnStartTouch != null)
        OnStartTouch(finger.screenPosition, Time.time);
}

private void Update()
{
    //Debug.Log(UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches);
    foreach(UnityEngine.InputSystem.EnhancedTouch.Touch touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
    {
        Debug.Log(touch.phase == UnityEngine.InputSystem.TouchPhase.Began);
    }
}

}
*/
