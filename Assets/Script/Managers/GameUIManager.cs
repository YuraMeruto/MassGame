///////////////////////////////////////
//製作者　名越大樹
//クラス　ゲーム上での情報を表示するクラス
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    PlayerUI playerUIScript;
    [SerializeField]
    PlayerManager playerManagerScript;
    [SerializeField]
    InformationUI infoMationScript;

    public void UpdateInfoTurn(InformationUI.Status set)
    {
        infoMationScript.UpdateInfoTurn(set);
    }

    public int GetPlayerNumber()
    {
        return playerManagerScript.GetPlayerNumber();
    }

    public void UpdateMassCount(int p1masscount, int p2masscount)
    {
        infoMationScript.UpdateMassCount(p1masscount, p2masscount);
    }

    public void ResultInformation(int p1, int p2)
    {
        infoMationScript.Result(p1, p2);
    }

    public void SetTurn(string turn)
    {
        playerUIScript.SetTurn(turn);
    }

    public void SetPlayerUI(int playernumber)
    {
        playerUIScript.SetPlayerUI(playernumber);
    }
}
