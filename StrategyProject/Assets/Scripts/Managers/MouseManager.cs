using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static Unit;

public class MouseManager : MonoBehaviour
{
    //public static Unit chosenUnit;

    //public GameObject MouseCursor;

    //public enum RoundTurn { SELECTUNIT, UNITACTION };
    //public RoundTurn playerTurn = RoundTurn.SELECTUNIT;

    //private void Update()
    //{

    //    //switch (GameManager.Instance.state)
    //    //{
    //    //    case GameManager.GameState.MAINMENU:
    //    //        break;
    //    //    case GameManager.GameState.PLAYERTURN:
    //    //        MouseHover();

    //    //        if (Input.GetMouseButtonDown(0))
    //    //        {
    //    //            LeftClick();
    //    //        }

    //    //        if (Input.GetMouseButtonDown(1))
    //    //        {
    //    //            RightClick();
    //    //        }
    //    //        break;
    //    //    case GameManager.GameState.ENEMYTURN:
    //    //        MouseHover();
    //    //        break;
    //    //    case GameManager.GameState.GAME:
    //    //        break;
            
    //    //}
    //}

    //void MouseHover()
    //{
    //    Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    Vector3Int gridPosition = LevelManager.Instance.WalkableMap.WorldToCell(mousepos);

    //    MouseCursor.transform.position = new Vector2(gridPosition.x + 0.5f, gridPosition.y + 0.5f);        
    //}

    //RaycastHit2D hit;

    //void LeftClick()
    //{
    //    Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    Vector3Int gridPosition = LevelManager.Instance.WalkableMap.WorldToCell(mousepos);

    //    hit = Physics2D.Raycast(mousepos, Vector2.zero);

    //    Unit unit;

    //    switch (playerTurn)
    //    {
    //        case RoundTurn.SELECTUNIT:
    //            if (!hit)
    //            {
    //                ClickedTile();
    //                return;
    //            }

    //            unit = hit.collider.GetComponent<Unit>();

    //            if (unit.state == UnitState.WAITING)
    //            {
    //                print(unit.name);
    //                chosenUnit = unit;

    //                playerTurn = RoundTurn.UNITACTION;

    //                EventManager.Instance.SelectedUnit(new Vector2Int(gridPosition.x, gridPosition.y));
    //            }
    //            break;
    //        case RoundTurn.UNITACTION:

    //            if (hit)
    //            {
    //                unit = hit.collider.GetComponent<Unit>();

    //                switch (unit.type)
    //                {
    //                    case UnitType.FRIENDLY:
    //                        break;
    //                    case UnitType.ENEMY:

    //                        chosenUnit.MoveUnit(GridManager.GetRoadMap());

    //                        //chosenUnit.AttackUnit(unit);

    //                        chosenUnit = null;
    //                        playerTurn = RoundTurn.SELECTUNIT;

    //                        EventManager.Instance.UnselectUnit();
    //                        break;
    //                    case UnitType.NPC:
    //                        break;
    //                }
    //                return;
    //            }

    //            //This might cause problems later, Remember this
    //            if (!ClickedTile())
    //                return;
    //            chosenUnit.MoveUnit(GridManager.GetRoadMap());
    //            //chosenUnit.MoveUnit(gridPosition);
    //            chosenUnit = null;

    //            playerTurn = RoundTurn.SELECTUNIT;
    //            EventManager.Instance.UnselectUnit();
    //            break;
    //    }
    //}

    //void RightClick()
    //{
    //    if (!chosenUnit)
    //        return;

    //    chosenUnit = null;
    //    playerTurn = RoundTurn.SELECTUNIT;

    //    EventManager.Instance.UnselectUnit();
    //}

    //bool ClickedTile()
    //{
    //    Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    Vector3Int gridPosition = LevelManager.Instance.WalkableMap.WorldToCell(mousepos);

    //    if (!LevelManager.Instance.IsValid(gridPosition))
    //        return false;

    //    return true;
    //}
}
