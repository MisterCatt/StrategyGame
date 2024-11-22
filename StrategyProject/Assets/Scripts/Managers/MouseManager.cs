using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MouseManager : MonoBehaviour
{
    public static MouseManager Instance;
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

    public GameObject mouseCursor;

    private Mouse _currentMouse;
    public Vector2 MousePosition { get; private set; }
    public Vector3Int GridPosition { get; private set; }

    private void Start()
    {
        _currentMouse = Mouse.current;
        mouseCursor.transform.parent = null;
    }

    private void Update()
    {
        MouseHover();
    }

    void MouseHover()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GridPosition = LevelManager.Instance.WalkableMap.WorldToCell(MousePosition);

        MousePosition = Camera.main.ScreenToWorldPoint(_currentMouse.position.ReadValue());

        Vector3Int gridPosition = LevelManager.Instance.WalkableMap.WorldToCell(MousePosition);

        mouseCursor.transform.position = new Vector2(gridPosition.x + 0.5f, gridPosition.y + 0.5f);

        
    }

    public void LeftClick()
    {
        if (!_currentMouse.leftButton.wasPressedThisFrame)
            return;

        EventManager.Instance.LeftClick(new Vector2(GridPosition.x, GridPosition.y));
    }

    public void RightClick()
    {
        if (!_currentMouse.rightButton.wasPressedThisFrame)
            return;

        EventManager.Instance.RightClick(new Vector2(GridPosition.x, GridPosition.y));
    }
}
