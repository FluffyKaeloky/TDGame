using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(TurretPawn))]
public class ClosestTargetAcquirer : BaseTargetAcquirer
{
    public float maxRange = 10.0f;
    public bool requireLOS = true;

    private TurretPawn turretPawn = null;

    private void Awake()
    {
        turretPawn = GetComponent<TurretPawn>();
    }

    public override Enemy AcquireTarget()
    {
        Enemy target = Physics.OverlapSphere(transform.position, maxRange, enemiesLayerMask)
            .Where(x => x.attachedRigidbody != null)
            .Distinct()
            .Select(x => x.GetComponentInParent<Enemy>())
            .Where(x => x != null)
            .Distinct()
            .OrderBy(x => Vector3.Distance(x.transform.position, transform.position))
            .FirstOrDefault(x => !requireLOS || HasLineOfSight(x));

        return target;
    }

    public override bool ConfirmTargetAcquisition(Enemy target)
    {
        if (requireLOS)
            return HasLineOfSight(target);
        return true;
    }

    public bool HasLineOfSight(Enemy target)
    {
        Vector3 targetVector = target.transform.position - turretPawn.axis.position;
        Ray ray = new Ray(turretPawn.axis.position, targetVector.normalized);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, targetVector.magnitude))
        {
            if (hitInfo.collider.transform.IsChildOf(target.transform))
                return true;
            return false;
        }
        else
            return true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.25f);
        Gizmos.DrawSphere(transform.position, maxRange);
    }
}
