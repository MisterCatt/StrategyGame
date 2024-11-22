using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_PlayerTurn : State
{
    public override void EnterState()
    {
        Debug.Log("Entered ingame ST_PlayerTurn");
    }
    public override void UpdateState()
    {
        MouseManager.Instance.LeftClick();
        MouseManager.Instance.RightClick();
    }

    public override void FixedUpdateState()
    {
        
    }
    public override void ExitState()
    {
        Debug.Log("Exited ingame ST_PlayerTurn");
    }
}
