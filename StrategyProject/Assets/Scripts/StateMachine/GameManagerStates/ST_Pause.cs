using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_Pause : State
{
    public override void EnterState()
    {
        Debug.Log("Entered GameManager ST_Pause");
    }
    public override void UpdateState()
    {
    }
    public override void ExitState()
    {
        Debug.Log("Exited GameManager ST_Pause");
    }
}
