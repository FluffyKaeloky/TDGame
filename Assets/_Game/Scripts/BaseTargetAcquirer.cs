using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class BaseTargetAcquirer : MonoBehaviour, ITargetAcquirer
{
    public LayerMask enemiesLayerMask = 0;

    public abstract Enemy AcquireTarget();
    public abstract bool ConfirmTargetAcquisition(Enemy target);
}
