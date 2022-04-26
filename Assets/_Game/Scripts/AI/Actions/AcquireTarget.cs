using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquireTarget : ActionTask
{
    public BBParameter<Enemy> targetOutput = null;

    private BaseTargetAcquirer targetAcquirer = null;

    protected override string OnInit()
    {
        targetAcquirer = agent.GetComponent<BaseTargetAcquirer>();

        return base.OnInit();
    }

    protected override void OnExecute()
    {
        targetOutput.value = targetAcquirer.AcquireTarget();

        EndAction(true);
    }
}
