using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [SerializeField]
    PlayerAction playerActionScript;
    [SerializeField]
    PlayerStatus playerStatusScript;
    [SerializeField]
    SocketStatus socketStatusScript;
    [SerializeField]
    MassManager massManagerScript;

    public int GetPlayerNumber()
    {
        return playerStatusScript.GetPlayerNumber();
    }

    public int GetTurn()
    {
        return playerStatusScript.GetTurn();
    }
    public void SetIsTurn(bool set)
    {
        playerStatusScript.SetIsTurn(set);
    }

    public bool MassRender(int playernumnber, int targetlength, int targetside)
    {
       return massManagerScript.MassRender(playernumnber, targetlength, targetside);
    }

    public void SetIsAction(bool set)
    {
        socketStatusScript.SetIsAction(true);
    }

    public void SetStatus(SocketStatus.Status set)
    {
        socketStatusScript.SetStatus(set);
    }

    public void SetSendData(string data)
    {
        socketStatusScript.SetSendData(data);
    }
}
