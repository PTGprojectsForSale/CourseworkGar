using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TracerSystem))]
[RequireComponent(typeof(PlasmagunLogic))]

public class CPlasmagun : CWeapon
{
    TracerSystem tracerSystem;
    PlasmagunLogic plasmagunLogic;

    void Start() => plasmagunLogic = GetComponent<PlasmagunLogic>();

    public override void fire()
    {
        //tracerSystem.createTracer(firePoint.position, firePoint.forward);
        plasmagunLogic.shot(firePoint, damage);
    }
}
