using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitManager : MonoBehaviour
{
    public List<CharacterController> unitList, PlayerUnits, NPCUnits, EnemyUnits;

    public CharacterController selectedUnit { get; private set; }

    public static UnitManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        EventManager.Instance.OnRightClick += UnSelectUnit;
        EventManager.Instance.OnLeftClick += MoveUnit;
    }

    public void SelectUnit(CharacterController character)
    {
        if(character)
            selectedUnit = character;
    }

    public void UnSelectUnit(Vector2 t)
    {
        selectedUnit = null;
    }

    public void MoveUnit(Vector2 positionToMove)
    {
        selectedUnit.MoveUnit(Astar.GetPath((Vector3Int)selectedUnit.GetPosition(), new Vector3Int((int)positionToMove.x, (int)positionToMove.y, 0), 5));
    }
}
