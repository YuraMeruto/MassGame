////////////////////////////////////
//製作者　名越大樹
//クラス　ゲーム上のマス全体を処理するクラス
////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassAction : MonoBehaviour
{
    [SerializeField]
    MassList massListScript;
    [SerializeField]
    GameObject instacePos;

    public void Ini()
    {
        Vector3 pos = instacePos.transform.position;
        int number = 0;
        for (int length = 0; length < massListScript.GetMassLengthSize(); length++)
        {
            for (int side = 0; side < massListScript.GetMassSideSize(); side++)
            {
                GameObject obj = massListScript.GetMassObj();
                GameObject instanceobj = Instantiate(obj, pos, Quaternion.identity);
                MassStatus status = instanceobj.GetComponent<MassStatus>();
                status.SetMassNumber(number, length, side);
                massListScript.SetMassStatus(length, side, status);
                pos.x += 2;
                number++;
            }
            pos.y--;
            pos.x = instacePos.transform.position.x;
        }
    }

    /// <summary>
    /// ゲーム上のマスの色を変える処理
    /// </summary>
    /// <param name="playernumnber"></param>
    /// <param name="targetlength"></param>
    /// <param name="targetside"></param>
    /// <returns></returns>
    public bool MassRender(int playernumnber, int targetlength, int targetside)
    {
        MassStatus[,] massarry = massListScript.GetMassStatusArray();
        int targetmass = massarry[targetlength, targetside].GetPlayerNumber();
        if (targetmass != playernumnber)
        {
            return false;
        }

        for (int length = targetlength; length >= 0; length--)
        {
            massarry[length, targetside].SetPlayerNumber(playernumnber);
        }

        for (int length = targetlength; length < massListScript.GetMassLengthSize(); length++)
        {
            massarry[length, targetside].SetPlayerNumber(playernumnber);
        }

        for (int side = targetside; side >= 0; side--)
        {
            massarry[targetlength, side].SetPlayerNumber(playernumnber);
        }

        for (int side = targetside; side < massListScript.GetMassSideSize(); side++)
        {
            massarry[targetlength, side].SetPlayerNumber(playernumnber);
        }
        return true;
    }


    /// <summary>
    /// サーバーから送られた最初にマスを塗る処理
    /// </summary>
    /// <param name="playernum"></param>
    /// <param name="massnum"></param>
    public void MassRender(int playernum, int massnum)
    {
        MassStatus[,] massarry = massListScript.GetMassStatusArray();
        for (int length = 0; length < massListScript.GetMassLengthSize(); length++)
        {
            for (int side = 0; side < massListScript.GetMassSideSize(); side++)
            {
                if (massnum == massarry[length, side].GetMassNumber())
                {
                    massarry[length, side].SetPlayerNumber(playernum);
                }
            }
        }
    }

    /// <summary>
    ///　プレイヤーが塗ったマスを数えるラス
    /// </summary>
    /// <param name="playernum"></param>
    /// <returns></returns>
    public int PlayerMassSumCount(int playernum)
    {
        MassStatus[,] massarray = massListScript.GetMassStatusArray();
        int num = 0;
        for (int length = 0; length < massListScript.GetMassLengthSize(); length++)
        {
            for (int side = 0; side < massListScript.GetMassSideSize(); side++)
            {
                if (playernum == massarray[length, side].GetPlayerNumber())
                {
                    num++;
                }
            }
        }
        return num;
    }

    /// <summary>
    ///　プレイヤーが塗ったマスを数える処理
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="playernum"></param>
    public void PlayerMassCount(ref int p1, ref int p2, int playernum)
    {
        MassStatus[,] massarray = massListScript.GetMassStatusArray();
        for (int length = 0; length < massListScript.GetMassLengthSize(); length++)
        {
            for (int side = 0; side < massListScript.GetMassSideSize(); side++)
            {
                if (massarray[length, side].GetPlayerNumber() == 1)
                {
                    p1++;
                }
                else if (massarray[length, side].GetPlayerNumber() == 2)
                {
                    p2++;
                }
            }
        }
    }
}
