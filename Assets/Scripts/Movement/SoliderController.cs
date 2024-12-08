using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderController : EnemyController
{
    public override void FixedUpdate()
    {
        target = FindObjectByTags();
        if (CanSeePlayer(target))
        {
            onLookEvent.Invoke(DirectionToTarget(target));
            onMoveEvent.Invoke(DirectionToTarget(target) * 0.5f);
        }
    }
    
}
