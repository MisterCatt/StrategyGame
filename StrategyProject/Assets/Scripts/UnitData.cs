using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType { FRIENDLY, ENEMY, NPC };

[CreateAssetMenu(fileName = "UnitData", menuName = "ScriptableObjects/UnitData", order = 1)]
public class UnitData : ScriptableObject
{
    public UnitType type = UnitType.FRIENDLY;

    public bool Alive;

    public int HP = 10, MaxHP = 10, Attack = 0, Defence = 0, Speed = 0, Evasion = 0;

    public string characterName = "";
}
