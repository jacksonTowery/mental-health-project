using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.EnhancedTouch;
//using static UnityEditor.Timeline.TimelinePlaybackControls;


public class TouchManager : MonoBehaviour
{

    private int YPosStart = 0;
    private int XPosStart = 0;

    private int YPosEnd = 0;
    private int XPosEnd = 0;

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
        Vector3 position = Camera.main.ScreenToWorldPoint(loc);
        position.z = player.transform.position.z;
        player.transform.position = position;
        Debug.Log("X pos: " + getXPos() + "  |  Y pos: " + getYPos());

    }

    private int getYPos()
    {
        return 0;
    }

    private int getXPos()
    {
        return 0;
    }

    private void Update()
    {
        if(touchPositionAction!=null)
            Debug.Log("X pos: "+getXPos()+"  |  Y pos: "+getYPos());
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
