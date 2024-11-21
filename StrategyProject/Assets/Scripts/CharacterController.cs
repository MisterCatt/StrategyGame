using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : Unit
{
    public enum UnitState { MOVING, WAITING, ATTACKING, DONE };

    [Header("Changable variables")]
    public UnitState state = UnitState.WAITING;

    private void Start()
    {
        UnitManager.Instance.unitList.Add(this);

        switch (type)
        {
            case UnitType.FRIENDLY:
                UnitManager.Instance.PlayerUnits.Add(this);
                break;
            case UnitType.ENEMY:
                UnitManager.Instance.EnemyUnits.Add(this);
                break;
            case UnitType.NPC:
                UnitManager.Instance.NPCUnits.Add(this);
                break;
        }
    }

    public void AwakeCharacter()
    {
        
    }

    public void StartCharacter()
    {
        movePoint.position = transform.position;

        movePoint.parent = null;
    }

    public void FixedUpdateCharacter()
    {
        snapToGrid();
    }

    //Works the same way as Update, gets updated via states instead
    public void UpdateCharacter()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, Speed * Time.deltaTime);
    }

    void snapToGrid()
    {
        Vector3Int gridPosition = LevelManager.Instance.WalkableMap.WorldToCell(transform.position);

        transform.position = new Vector2(gridPosition.x + 0.5f, gridPosition.y + 0.5f);

        movePoint.position = transform.position;
    }

    public void MoveUnit(List<Spot> path)
    {
        StartCoroutine(WalkToPosition(path));
    }

    IEnumerator WalkToPosition(List<Spot> path)
    {
        state = UnitState.MOVING;
        while (path.Count > 1)
        {
            movePoint.position = new Vector3(path[path.Count - 1].X + 0.5f, path[path.Count - 1].Y + 0.5f, 0);

            yield return new WaitForPositionReached(transform, movePoint);

            path.RemoveAt(path.Count - 1);
        }
    }


    public TileData GetTileUnder()
    {
        return LevelManager.Instance.GetTileData(LevelManager.Instance.WalkableMap.WorldToCell(transform.position));
    }

    public Vector2Int GetPosition()
    {
        Vector3Int gridPosition = LevelManager.Instance.WalkableMap.WorldToCell(transform.position);

        return new Vector2Int(gridPosition.x, gridPosition.y);

    }
}
