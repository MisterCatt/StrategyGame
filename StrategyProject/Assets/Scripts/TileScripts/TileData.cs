using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Tile", menuName = "ScriptableObjects/Tile", order = 1)]
public class TileData : ScriptableObject
{

    public TileBase[] tiles;

    public bool isBlocking;

    public int walkingCost, TileDefenceModifier, TileAttackModifier;

    public enum TileType { GRASS, STONE};
    public TileType tileType;

}
