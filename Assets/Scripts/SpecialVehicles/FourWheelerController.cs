using System;
using UnityEngine;

public class FourWheelerController : VehicleGraphicsController
{
    [Space(6)] 
    [Header("----- End of Master Settings -----",order = 0)]
    [Space(6)]
    [Header("Wheel Mesh References",order = 1)]
    [Tooltip("Front Wheels")] public GameObject[] frontWheels;
    [Tooltip("Rear Wheels")] public GameObject[] rearWheels;
    

    protected override void BeforeBeginPlay()
    {
        
    }
    
    protected override void BeginPlay()
    {
        
    }
    
    protected override void Tick()
    {
        if (InputManager.RudderInput > DeadZoneValue)
        {
            Debug.Log("Turn Front Wheels Right");
        }
        else if(InputManager.RudderInput < -DeadZoneValue)
        {
            Debug.Log("Turn Front Wheels Left");
        }
        else
        {
            Debug.Log("Wheels Position Idle");
        }
    }

    protected override void FixedTick()
    {
        
    }


}
