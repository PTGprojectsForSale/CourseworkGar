using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TracerSystem))]
[RequireComponent(typeof(RevolverLogic))]

public class CRevolver : CWeapon
{
    TracerSystem tracerSystem;
    RevolverLogic machineugnLogic;

    void Start()
    {
        machineugnLogic = GetComponent<RevolverLogic>();
        tracerSystem = GetComponent<TracerSystem>();
    }
    public override void fire()
    {
        tracerSystem.createTracer(firePoint.position, firePoint.forward);
        machineugnLogic.shot(firePoint, damage);
    }

    public override WeaponTypes getWeaponType()
    {
        return WeaponTypes.Mashinegun;
    }
}
