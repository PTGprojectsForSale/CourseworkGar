using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TracerSystem))]
[RequireComponent(typeof(MachinegunLogic))]

public class CMachinegun : CWeapon
{
    TracerSystem tracerSystem;
    MachinegunLogic machineugnLogic;

    void Start()
    {
        machineugnLogic = GetComponent<MachinegunLogic>();
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
