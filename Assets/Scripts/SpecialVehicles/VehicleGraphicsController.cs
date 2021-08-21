using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VehicleGraphicsController : MonoBehaviour
{
    #region References
    private InputManager _inputManager;
    public InputManager InputManager => _inputManager;
    #endregion
    #region Master Settings

    [Space(6)] 
    [Header("----- Start of Master Settings -----",order = 0)]
    
    [Space(6)]
    [Header("Preference Settings",order = 1)]
    [Tooltip("Does the Body show roll when Rudder input is provided")] public bool hasAngleRoll;
    #endregion
    #region Helper Variables
    
    private float _deadZoneValue = 0.1f;
    public float DeadZoneValue => _deadZoneValue;

    #endregion
    
    [Space(6)]
    [Header("Visual Settings",order = 2)]
    [Tooltip("Angle to which to tilt the Vehicle Body")] public float angleOfRoll = 30f; //Banking Angle
    [Tooltip("Vehicle Graphics GameObject")] public GameObject vehicleBody;

    #region Unity Defined Functions
    
    /// <summary>
    /// Use this function instead of Awake for all Child Classes of VehicleGraphicsController
    /// </summary>
    protected abstract void BeforeBeginPlay();
    
    /// <summary>
    /// Use this function instead of Start for all Child Classes of VehicleGraphicsController
    /// </summary>
    protected abstract void BeginPlay();
    
    /// <summary>
    /// Use this function instead of Update for all Child Classes of VehicleGraphicsController
    /// </summary>
    protected abstract void Tick();

    /// <summary>
    /// Use this function instead of FixedUpdate for all Child Classes of VehicleGraphicsController
    /// </summary>
    protected abstract void FixedTick();
    
    #endregion
    
    void Awake()
    {
        BeforeBeginPlay();
        _inputManager = GetComponent<InputManager>();
    }
    
    void Start()
    {
        BeginPlay();
    }

    void Update()
    {
        Tick();
        
        if(hasAngleRoll)
            HandleStraightAngleRolling();
    }

    private void FixedUpdate()
    {
        FixedTick();
    }

    void HandleStraightAngleRolling()
    {
        float angle;
        //Banking Angle Graphics Calculation
        if (_inputManager.ThrustInput != 0f)
            angle = angleOfRoll * -_inputManager.RudderInput;
        else
            angle = 0f;

        Quaternion bodyRotation = transform.rotation * Quaternion.Euler(0f, 0f, angle);
        vehicleBody.transform.rotation = Quaternion.Lerp(vehicleBody.transform.rotation,bodyRotation,Time.deltaTime * 10f);
    }
}
