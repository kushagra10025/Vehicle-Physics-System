using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    [SerializeField] private float _thrustInput;
    [SerializeField] private float _rudderInput;
    [SerializeField] private bool _brakeInput;
    [SerializeField] private bool _resetPositionInput;

    public float ThrustInput => _thrustInput;
    public float RudderInput => _rudderInput;
    public bool BrakeInput => _brakeInput;
    public bool ResetPositionInput => _resetPositionInput;

    private void OnEnable()
    {
        if (_playerInputActions == null)
        {
            _playerInputActions = new PlayerInputActions();

            _playerInputActions.PlayerControls.Thrust.performed += i => _thrustInput = i.ReadValue<float>();
            _playerInputActions.PlayerControls.Rudder.performed += i => _rudderInput = i.ReadValue<float>();
            _playerInputActions.PlayerControls.Brake.performed += i => _brakeInput = (i.ReadValue<float>() > 0.5f) ? true : false;
            
            _playerInputActions.DebugActions.ResetPosition.performed += i => _resetPositionInput = (i.ReadValue<float>() > 0.5f) ? true : false;
        }
        _playerInputActions.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Disable();
    }
}
