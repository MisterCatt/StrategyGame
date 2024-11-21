using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_NPCTurn : State
{
    public override void EnterState()
    {
        Debug.Log("Entered ingame ST_NPCTurn");
    }
    public override void UpdateState()
    {
    }
    public override void ExitState()
    {
        Debug.Log("Exited ingame ST_NPCTurn");
    }
}
