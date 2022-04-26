using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : ActionTask
{
    public BBParameter<Enemy> target = null;

    private float lastFireTime = 0.0f;

    private TurretPawn turretPawn = null;
    private BaseTargetAcquirer targetAcquirer = null;

    protected override string OnInit()
    {
        turretPawn = agent.GetComponent<TurretPawn>();
        targetAcquirer = agent.GetComponent<BaseTargetAcquirer>();

        return base.OnInit();
    }

    protected override void OnUpdate()
    {
        if (target == null || target.value == null)
        {
            EndAction(false);
            return;
        }

        turretPawn.MoveUpdate(target.value);

        if (target.value == null || !targetAcquirer.ConfirmTargetAcquisition(target.value))
        {
            EndAction(false);
            return;
        }

        if (Time.time - lastFireTime > turretPawn.fireRate && turretPawn.IsAligned(target.value))
        {
            turretPawn.Fire(target.value);

            Debug.DrawLine(turretPawn.fireMuzzle.position, target.value.transform.position, Color.red, 0.5f);

            lastFireTime = Time.time;

            EndAction(true);
        }
    }
}
