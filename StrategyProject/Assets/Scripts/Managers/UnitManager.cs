using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<CharacterController> unitList, PlayerUnits, NPCUnits, EnemyUnits;

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
}
