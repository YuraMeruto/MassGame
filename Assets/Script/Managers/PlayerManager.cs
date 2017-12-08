//////////////////////////////////////
//製作者　名越大樹
//クラス　プレイヤー以外と中継をするクラス
//////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    PlayerAction playerActionScript;
    [SerializeField]
    PlayerStatus playerStatusScript;
    [SerializeField]
    SocketStatus socketStatusScript;
    [SerializeField]
    MassManager massManagerScript;
    [SerializeField]
    GameUIManager gameUIManagerScript;

    public int GetPlayerNumber()
    {
        return playerStatusScript.GetPlayerNumber();
    }

    public void UpdateInfoTurn()
    {
        gameUIManagerScript.UpdateInfoTurn(InformationUI.Status.EnemyTurn);
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

    public void SetStatus(SocketStatus.Status set)
    {
        socketStatusScript.SetStatus(set);
    }

    public void SetSendData(string data)
    {
        socketStatusScript.SetSendData(data);
    }

    public void PlayerMassCount(ref int p1, ref int p2, int playernum)
    {
        massManagerScript.PlayerMassCount(ref p1, ref p2, playernum);
    }

    public void UpdateMassCount(int p1, int p2)
    {
        gameUIManagerScript.UpdateMassCount(p1, p2);
    }
}
