using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    #region Private Variables - References
    
    private Rigidbody _rigidbody;
    private InputManager _inputManager;

    #endregion

    private float _deadZone = 0.1f;

    #region Public Variables
    
    [Space(6)]
    [Header("Hover Settings")]
    [Tooltip("Tweak the PID Controller for adding forces while hovering")] public PIDController hoverHeightPID;
    [Tooltip("Add the GameObjects to shoot raycast for suspension")] public GameObject[] hoverPoints;
    [Tooltip("Ideal HoverForce per HoverPoint")] public float hoverForce = 1000f;
    [Tooltip("Height from Ground for the HoverPoint to be. or Suspension Height")] public float hoverHeight = 1.5f;
    
    [Space(6)]
    [Header("Vehicle Physics Settings")]
    [Tooltip("Force multiplier towards Forward Acceleration.")] public float forwardAcceleration = 8000f;
    [Tooltip("Force multiplier towards Reverse Acceleration.")] public float reverseAcceleration = 4000f;
    [Tooltip("Force towards Ground Drag.")] public float groundedDrag = 3f;
    [Tooltip("Rigidbody Max Velocity Limit.")] public float maxVelocity = 50f;
    [Tooltip("Force multiplier towards Rotation Torque.")] public float turnStrength = 1000f;
    [Tooltip("Transform for positioning COM of the Vehicle.")] public Transform COM;
    [Range(1f,5000f)] 
    [Tooltip("Friction on vehicle while moving on Surfaces. Change for various surface effects")] public float sidewayFrictionCoeff = 3000f;
    
    [Space(6)]
    [Header("World Physics Settings")]
    [Tooltip("Do we apply custom gravity? If checked uncheck Rigidbody UseGravity and vice versa")] public bool applyCustomGravity;
    [Tooltip("Value used only when ApplyCustomGravity is checked")] public float gravityForce = 1.6f;
    
    [Space(6)]
    [Header("Grounding Settings")]
    [Tooltip("What Layers are to be considered as Ground?")] public LayerMask whatIsGround;
    [Tooltip("Is the vehicle currently grounded?")] public bool isGrounded;
    [Tooltip("Normal of the ground the vehicle is currently on")] public Vector3 groundNormal;
    [Tooltip("Do we want to rotate the vehicle along to the Ground Normal?")]public bool rotateAlongGround = true;
    
    #endregion

    #region Debug Variables
    
    [Header("Debug Options")]
    public bool useSphereCast = true;
    public Transform lastPointToSpawn;
    
    #endregion
    
    #region Private Variables - Value Calculators
    
    private float thrust = 0f;
    private float _turnValue = 0f;
    private float _torque;  

    #endregion
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputManager = GetComponent<InputManager>();

        COM.position = Vector3.down;
        _rigidbody.centerOfMass = COM.position;
    }

    private void Update()
    {
        // Thrust Input
        thrust = 0.0f;
        float acceleration = _inputManager.ThrustInput;
        if (acceleration > _deadZone)
            thrust = acceleration * forwardAcceleration;
        else if(acceleration < -_deadZone)
            thrust = acceleration * reverseAcceleration;
        
        // Rudder Input
        _turnValue = 0.0f;
        float rudder = _inputManager.RudderInput;
        if (Mathf.Abs(rudder) > _deadZone && acceleration > _deadZone)
            _turnValue = rudder;
        else
            _turnValue = -rudder;
        
        // Reset Position Input
        if (_inputManager.ResetPositionInput)
        {
            lastPointToSpawn.position = new Vector3(lastPointToSpawn.position.x,lastPointToSpawn.position.y,lastPointToSpawn.position.z);
            transform.position = lastPointToSpawn.position;
        }
    }
    private void FixedUpdate()
    {
        if(applyCustomGravity)
            ApplyGravity();
        
        GroundNormal();
        HoverForces();
        HandleForwardAndReverseForces();
        HandleTurnForces();
        HandleSidewaysFriction();
        LimitMaxVelocity();
        
        //Debug Jump Code
        //TODO: Remove Later
        if (_inputManager.BrakeInput && isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * 100f, ForceMode.Impulse);
        }
    }

    private void GroundNormal()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, hoverHeight, whatIsGround))
        {
            groundNormal = hit.normal;
            if (hit.transform.CompareTag("Mud"))
            {
                sidewayFrictionCoeff = 5000f;
            }
            else if (hit.transform.CompareTag("Ice"))
            {
                sidewayFrictionCoeff = 1f;
            }
            else
            {
                sidewayFrictionCoeff = 3000f;
            }
        }
    }

    private Vector3 gravityVector;
    private void ApplyGravity()
    {
        gravityVector = Vector3.down * (_rigidbody.mass * gravityForce);
        _rigidbody.AddForce(gravityVector);
    }

    private void HandleForwardAndReverseForces()
    {
        // Handle Forward and Reverse forces
        if (Mathf.Abs(thrust) > 0)
            _rigidbody.AddForce(transform.forward * thrust);

        if(rotateAlongGround)
        {
            //Add Rotation to the Vehicle depending on below surface
            //Removes Jerkiness
            Vector3 projection = Vector3.ProjectOnPlane(transform.forward, groundNormal);
            Quaternion rotation = quaternion.LookRotation(projection, groundNormal);

            _rigidbody.MoveRotation(Quaternion.Lerp(_rigidbody.rotation, rotation, Time.deltaTime * 10f));
        }
    }
    
    private void HandleTurnForces()
    {
        // Handle Turn forces

        float ts;
        //Air Controls
        //ts = (!isGrounded) ? (turnStrength * 100f / 4f) : turnStrength;
        ts = turnStrength;
        float currentTorqueValue = (_turnValue * ts);
        _torque = currentTorqueValue;
        
        if(_turnValue != 0 && _inputManager.ThrustInput != 0f)    
        {
            _rigidbody.AddRelativeTorque(Vector3.up * _torque);
        }
    }

    private void HandleSidewaysFriction()
    {
        //Reference Link
        //https://www.reddit.com/r/gamedev/comments/8ms6ib/how_do_i_find_the_local_sideways_velocity_of_an/
        //On Changing the values of the sidewayFrictionCoeff we can simulate different surfaces.
        float forceMultiplier = sidewayFrictionCoeff;
        Vector3 worldVector = _rigidbody.velocity;
        Vector3 localVector = transform.InverseTransformVector(worldVector);
        Vector3 localForce = new Vector3(localVector.x * -forceMultiplier, 0f, 0f);
        Vector3 worldForce = transform.TransformVector(localForce);
        
        _rigidbody.AddForce(worldForce);
    }

    private void LimitMaxVelocity()
    {
        // Limit max velocity
        if(_rigidbody.velocity.sqrMagnitude > (_rigidbody.velocity.normalized * maxVelocity).sqrMagnitude)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * maxVelocity;
        }
    }

    private void HoverForces()
    {
        RaycastHit hit;
        isGrounded = false;
        foreach (var hoverPoint in hoverPoints)
        {
            if(useSphereCast)
            {
                if (Physics.SphereCast(hoverPoint.transform.position, 0.2f, Vector3.down, out hit, hoverHeight,
                    whatIsGround))
                {
                    float compressionRatio = (1.0f - (hit.distance / hoverHeight));
                    //_rigidbody.AddForceAtPosition(Vector3.up * (hoverForce * compressionRatio), hoverPoint.transform.position);
                    //Add If PID
                    float desiredHeight = hoverHeightPID.GetOutput(compressionRatio, Time.fixedDeltaTime);
                    _rigidbody.AddForceAtPosition(Vector3.up * (hoverForce * desiredHeight),
                        hoverPoint.transform.position);
                    isGrounded = true;
                }
            }
            else
            {
                if (Physics.Raycast(hoverPoint.transform.position, Vector3.down, out hit, hoverHeight, whatIsGround))
                {
                    float compressionRatio = (1.0f - (hit.distance / hoverHeight));
                    //_rigidbody.AddForceAtPosition(Vector3.up * (hoverForce * compressionRatio), hoverPoint.transform.position);
                    //Add If PID
                    float desiredHeight = hoverHeightPID.GetOutput(compressionRatio, Time.fixedDeltaTime);
                    _rigidbody.AddForceAtPosition(Vector3.up * (hoverForce * desiredHeight),
                        hoverPoint.transform.position);
                    isGrounded = true;
                }
            }
        }

        if (isGrounded)
        {
            _rigidbody.drag = groundedDrag;
        }
        else
        {
            _rigidbody.drag = 0.1f;
            thrust /= 100f;
            _turnValue /= 100f;
        }
    }

    private void OnDrawGizmos()
    {
        DrawForces();
    }

    private void DrawForces()
    {
    }
}
