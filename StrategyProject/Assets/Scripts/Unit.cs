using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : UnitStats
{
    [SerializeField]
    protected Transform movePoint;

    public int GetHP() => HP;
    public int GetMaxHP() => MaxHP;
    public int GetAttack() => Attack;
    public int GetDefence() => Defence;
    public int GetSpeed() => Speed;
    public void SetSpeed(int speed) => Speed = speed;
    public int GetEvasion() => Evasion;
    public string GetName() => characterName;
    public bool GetAlaveState() => Alive;
    public void SetAlive(bool alive) => Alive = alive;
}
