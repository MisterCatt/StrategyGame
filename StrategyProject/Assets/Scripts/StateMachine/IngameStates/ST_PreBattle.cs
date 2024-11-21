using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_PreBattle : State
{
    public override void EnterState()
    {
        Debug.Log("Entered ingame ST_PreBattle");
    }
    public override void UpdateState()
    {
    }
    public override void ExitState()
    {
        Debug.Log("Exited ingame ST_PreBattle");
    }
}
