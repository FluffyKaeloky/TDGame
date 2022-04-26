using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichAIMoveTo : ActionTask
{
    public bool useEndGoal = false;
    [ShowIf("useEndGoal", 0)]
    public BBParameter<Vector3> target = null;

    private IAstarAI movement = null;

    protected override string OnInit()
    {
        movement = agent.GetComponent<IAstarAI>();

        return base.OnInit();
    }

    protected override void OnExecute()
    {
        if (useEndGoal)
            movement.destination = LevelManager.Instance.endGoal.position;
        else if (target != null)
            movement.destination = target.value;
        else
        {
            EndAction(false);
            return;
        }

        movement.isStopped = false;
    }

    protected override void OnUpdate()
    {
        if (movement.reachedDestination)
            EndAction(true);
    }
}
