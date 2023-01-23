using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class _inputManger : Singleton<_inputManger>
{
    #region Events
    
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    
    #endregion
    
    //public vars
    
    //private vars
    private PlayerControls playerControls;
    private Camera mainCam;
    
    private void Awake()
    {
        playerControls = new PlayerControls();
        mainCam = Camera.main;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    
    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null)
        {
            OnStartTouch(_utils.ScreenToWorld(mainCam,playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
        }
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
        {
            OnEndTouch(_utils.ScreenToWorld(mainCam, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
        }
    }

    public Vector2 PrimaryPosition()
    {
        return _utils.ScreenToWorld(mainCam, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
    }
    
    private void Start()
    {
        playerControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        playerControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }
}
