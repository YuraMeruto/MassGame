using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    [SerializeField]
    int playerNumber;
    [SerializeField]
    bool isTurn;
    [SerializeField]
    LayerMask massLayer;
    [SerializeField]
    bool isOnline = false;
    [SerializeField]
    int turnCount;
    public bool GetIsOnline()
    {
        return isOnline;
    }

    public void SetIsOnline(bool set)
    {
        isOnline = set;
    }
    public void SetPlayerNumber(int set)
    {
        playerNumber = set;
    }

    public int GetPlayerNumber()
    {
        return playerNumber;
    }

    public void SubtractionTurn()
    {
        turnCount--;
    }

    public int GetTurn()
    {
        return turnCount;
    }

    public void SetIsTurn(bool set)
    {
        isTurn = set;
    }

    public bool GetIsTurn()
    {
        return isTurn;
    }

    public LayerMask GetMassLayer()
    {
        return massLayer;
    }
}
