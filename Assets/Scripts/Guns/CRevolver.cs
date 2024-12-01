using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

[RequireComponent(typeof(TracerSystem))]
[RequireComponent(typeof(RevolverLogic))]

public class CRevolver : CWeapon
{
    TracerSystem tracerSystem;
    RevolverLogic RevolverLogic;

    void Start()
    {
        RevolverLogic = GetComponent<RevolverLogic>();
        tracerSystem = GetComponent<TracerSystem>();
    }
    public override void fire()
    {
        base.fire();

        tracerSystem.createTracer(firePoint.position);
        RevolverLogic.shot(firePoint, damage);
    }
}
