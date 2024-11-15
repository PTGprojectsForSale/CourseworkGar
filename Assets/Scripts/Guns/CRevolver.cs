using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TracerSystem))]
[RequireComponent(typeof(RevolverLogic))]

public class CRevolver : CWeapon
{
    TracerSystem tracerSystem;
    RevolverLogic revolverLogic;

    void Start()
    {
        revolverLogic = GetComponent<RevolverLogic>();
        tracerSystem = GetComponent<TracerSystem>();
    }
    public override void fire()
    {
        tracerSystem.createTracer(firePoint.position, firePoint.forward);
        revolverLogic.shot(firePoint, damage);
    }
}
