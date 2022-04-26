using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPawn : MonoBehaviour
{
    public Transform axis = null;
    public Transform fireMuzzle = null;

    public float rotationSpeed = 180.0f;
    public float slowdownTime = 0.1f;

    public float alignedAngleDelta = 5.0f;

    public float fireRate = 1.0f;
    public float fireDamage = 10.0f;

    public void MoveUpdate(Enemy target)
    {
        if (target == null)
            return;

        Vector3 targetDirection = (target.transform.position - axis.position).normalized;
        Debug.DrawLine(axis.position, axis.position + targetDirection * 10.0f, Color.red);
        Vector3 currentDirection = axis.forward;
        Debug.DrawLine(axis.position, axis.position + targetDirection * 10.0f, Color.blue);

        float deltaAngle = Vector3.Angle(targetDirection, currentDirection);

        Vector3 newDirection = Vector3.RotateTowards(currentDirection, targetDirection, Mathf.Clamp01(deltaAngle / (slowdownTime * rotationSpeed)) * Mathf.Deg2Rad * (rotationSpeed) * Time.deltaTime, 0.0f);

        axis.rotation = Quaternion.LookRotation(newDirection);
    }

    public bool IsAligned(Enemy target)
    {
        Vector3 targetDirection = (target.transform.position - axis.position).normalized;

        if (Vector3.Angle(axis.forward, targetDirection) > alignedAngleDelta)
            return false;
        return true;
    }

    public void Fire(Enemy target)
    {
        target.HealthManager.TakeDamage(fireDamage);
    }
}
