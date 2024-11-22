using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerTurn { PLAYER, ENEMY, NPC, DEFAULT}

public class GameController : StateMachine
{
    public static GameController Instance;

    public bool StartLevelOnEnemyTurn = false;

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
        SwapTurn(PlayerTurn.DEFAULT);
    }

    public void StartGame()
    {
        SwapTurn(StartLevelOnEnemyTurn ? PlayerTurn.ENEMY : PlayerTurn.PLAYER);
    }

    [SerializeField]
    private PlayerTurn playerTurn;
    public Action<PlayerTurn> OnChangeTurn;

    public void SwapTurn(PlayerTurn turn)
    {
        playerTurn = turn;

        switch (turn)
        {
            case PlayerTurn.PLAYER:
                ChangeState<ST_PlayerTurn>();
                break;
            case PlayerTurn.ENEMY:
                //ChangeState<>();
                break;
            case PlayerTurn.NPC:
                //ChangeState<>();
                break;
            case PlayerTurn.DEFAULT:
                //ChangeState<>();
                break;
            default:
                break;
        }

        
        OnChangeTurn?.Invoke(playerTurn);
    }


}
