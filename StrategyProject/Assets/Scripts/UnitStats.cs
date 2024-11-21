using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public UnitType type;

    [SerializeField]
    private UnitData unitData;

    protected bool Alive;

    protected int HP, MaxHP, Attack, Defence, Speed, Evasion;

    protected string characterName;

    private void Awake()
    {
        type = unitData.type;
        Alive = unitData.Alive;

        HP = unitData.HP;
        MaxHP = unitData.MaxHP;
        Attack = unitData.Attack;
        Defence = unitData.Defence;
        Speed = unitData.Speed;
        Evasion = unitData.Evasion;

        characterName = unitData.characterName;
    }
}
