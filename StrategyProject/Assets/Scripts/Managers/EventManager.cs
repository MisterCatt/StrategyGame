using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public static EventManager Instance;
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

    public event Action OnLevelLoaded;

    public void LevelLoaded()
    {
        OnLevelLoaded?.Invoke();
    }

    public event Action<Vector2Int> OnSelectUnit;
    public event Action OnUnSelectUnit;

    public void SelectedUnit(Vector2Int gridPosition)
    {
        OnSelectUnit?.Invoke(gridPosition);
    }

    public void UnselectUnit()
    {
        OnUnSelectUnit?.Invoke();
    }
}
