using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public Tilemap WalkableMap;

    public List<TileData> tileData;

    private Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            Destroy(gameObject);
            return;
        }

        Instance = this;

        dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach (var tileData in tileData)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }

    public Sprite GetTileSprite(Vector3Int position)
    {
        return WalkableMap.GetSprite(position);
    }

    public TileData GetTileData(Vector2 position)
    {
        Vector3Int posInt = new Vector3Int((int)position.x, (int)position.y, 0);

        return dataFromTiles[WalkableMap.GetTile(posInt)];
    }

    public TileData GetTileData(Vector3Int position)
    {
        return dataFromTiles[WalkableMap.GetTile(position)];
    }

    public TileBase GetTileBase(Vector2 position)
    {
        Vector3Int posInt = new Vector3Int((int)position.x, (int)position.y, 0);

        return WalkableMap.GetTile(posInt);
    }

    public TileBase GetTileBase(Vector3Int position)
    {
        return WalkableMap.GetTile(position);
    }

    public bool IsValid(Vector3Int pos)
    {
        if (WalkableMap.GetTile(pos))
        {
            return true;
        }
        return false;
        
    }
}
