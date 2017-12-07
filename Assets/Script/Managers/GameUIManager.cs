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

    public int GetPlayerNumber()
    {
        return playerManagerScript.GetPlayerNumber();
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
