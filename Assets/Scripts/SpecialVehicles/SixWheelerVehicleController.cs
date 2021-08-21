using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixWheelerVehicleController : VehicleGraphicsController
{
    [Space(6)] 
    [Header("----- End of Master Settings -----", order = 0)]
    [Header("Wheel Mesh References",order = 1)]
    [Tooltip("Front Wheels")] public GameObject[] frontWheels;
    [Tooltip("Middle Wheels")] public GameObject[] midWheels;
    [Tooltip("Rear Wheels")] public GameObject[] rearWheels;
    protected override void BeforeBeginPlay()
    {
    }

    protected override void BeginPlay()
    {
    }

    protected override void Tick()
    {
    }

    protected override void FixedTick()
    {
    }
}
