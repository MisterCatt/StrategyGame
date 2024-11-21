using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_EnemyTurn : State
{
    public override void EnterState()
    {
        Debug.Log("Entered ingame ST_EnemyTurn");
    }
    public override void UpdateState()
    {
    }
    public override void ExitState()
    {
        Debug.Log("Exited ingame ST_EnemyTurn");
    }
}
