using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public Tilemap walkableMap;
    public Tilemap roadMap;
    public TileBase roadTile;
    public static List<Vector3Int> Tiles;
    static List<Spot> roadPath = new List<Spot>();
    new Camera camera;
    BoundsInt bounds;

    bool createPath = false;
    // Start is called before the first frame update

    private void OnDisable()
    {
        EventManager.Instance.OnSelectUnit -= StartDrawingPath;
        EventManager.Instance.OnUnSelectUnit -= StopDrawingPath;
    }

    void Start()
    {
        EventManager.Instance.OnSelectUnit += StartDrawingPath;
        EventManager.Instance.OnUnSelectUnit += StopDrawingPath;

        walkableMap.CompressBounds();
        roadMap.CompressBounds();
        bounds = walkableMap.cellBounds;
        camera = Camera.main;


        CreateGrid();
    }

    public void CreateGrid()
    {
        Tiles = new List<Vector3Int>();

        for (int x = bounds.xMin, i = 0; i < (bounds.size.x); x++, i++)
        {
            for (int y = bounds.yMin, j = 0; j < (bounds.size.y); y++, j++)
            {
                if (walkableMap.HasTile(new Vector3Int(x, y, 0)))
                {
                    Tiles.Add(new Vector3Int(x, y, 0));
                }
                else
                {
                    Tiles.Add(new Vector3Int(x, y, 1));
                }
            }
        }
    }

    void StartDrawingPath(Vector2Int gridPosition)
    {
        createPath = true;

        start = gridPosition;
    }

    void StopDrawingPath()
    {
        createPath = false;

        start = new Vector2Int(0, 0);

        roadMap.ClearAllTiles();
    }

    private void DrawRoad()
    {
        for (int i = 0; i < roadPath.Count; i++)
        {
            roadMap.SetTile(new Vector3Int(roadPath[i].X, roadPath[i].Y, 0), roadTile);
        }
    }
    // Update is called once per frame
    public Vector2Int start;
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            Vector3 world = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = walkableMap.WorldToCell(world);
            roadMap.SetTile(new Vector3Int(gridPos.x, gridPos.y, 0), null);
        }

        if(createPath)
        {
            roadMap.ClearAllTiles();

            CreateGrid();

            Vector3 world = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = walkableMap.WorldToCell(world);

            if (roadPath != null && roadPath.Count > 0)
                roadPath.Clear();

            //roadPath = astar.CreatePath(spots, start, new Vector2Int(gridPos.x, gridPos.y), MouseManager.chosenUnit.GetSpeed());
            if (roadPath == null)
                return;

            DrawRoad();

            
            //start = new Vector2Int(roadPath[0].X, roadPath[0].Y);
        }
    }

    public static List<Spot> GetRoadMap()
    {
        return roadPath;
    }
}