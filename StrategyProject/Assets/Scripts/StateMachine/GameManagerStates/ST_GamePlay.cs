using UnityEngine;
using UnityEngine.InputSystem;


public class ST_GamePlay : State
{
    public override void EnterState()
    {
        Debug.Log("Entered GameManager ST_Gameplay");

        foreach (var unit in UnitManager.Instance.unitList)
        {
            unit.StartCharacter();
        }
    }
    public override void UpdateState()
    {
        foreach (var unit in UnitManager.Instance.unitList)
        {
            unit.UpdateCharacter();
        }

        MouseManager.Instance.RightClick();
        MouseManager.Instance.LeftClick();
    }

    public override void FixedUpdateState()
    {
        foreach (var unit in UnitManager.Instance.unitList)
        {
            unit.FixedUpdateCharacter();
        }
    }
    public override void ExitState()
    {
        Debug.Log("Exited GameManager ST_Gameplay");
    }
}
