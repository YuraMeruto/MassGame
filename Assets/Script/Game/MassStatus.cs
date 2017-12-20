//////////////////////////////////////
//製作者　名越大樹
//クラス　マスのステータスに関するクラス
//////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassStatus : MonoBehaviour
{
    [SerializeField]
    Renderer render;
    [SerializeField]
    Material[] material;
    int playerNumber = 0;
    [SerializeField]
    int massNumber;
    [SerializeField]
    int lengthNumber;
    [SerializeField]
    int sideNumber;

    public void SetPlayerNumber(int set)
    {
        playerNumber = set;
        SetRenderMassColor();
    }

    void SetRenderMassColor()
    {
        render.material = material[playerNumber];
    }

    public int GetPlayerNumber()
    {
        return playerNumber;
    }

    public void SetMassNumber(int set, int length, int side)
    {
        massNumber = set;
        lengthNumber = length;
        sideNumber = side;
    }

    public int GetMassNumber()
    {
        return massNumber;
    }

    public void GetLengthSideNumber(ref int length, ref int side)
    {
        length = lengthNumber;
        side = sideNumber;
    }
}
