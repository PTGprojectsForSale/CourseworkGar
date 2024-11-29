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
        float spread = 5f;

        var angle_x = Random.Range(-spread / 2, spread / 2);
        var angle_y = Random.Range(-spread / 2, spread / 2);
        var angle_z = Random.Range(-spread / 2, spread / 2);
        var quaternion = Quaternion.Euler(angle_x, angle_y, angle_z);
        Vector3 dir = quaternion * firePoint.forward;

        tracerSystem.createTracer(firePoint.position, dir);
        machineugnLogic.shot(firePoint, damage);
    }

    public override WeaponTypes getWeaponType()
    {
        return WeaponTypes.Mashinegun;
    }
}
