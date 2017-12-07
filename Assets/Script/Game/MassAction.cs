using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassAction : MonoBehaviour {
    [SerializeField]
    MassList massListScript;
    [SerializeField]
    GameObject instacePos;
    public void Ini()
    {
        Debug.Log("マスの生成開始");
        Vector3 pos = instacePos.transform.position;
        int number = 0;
        for (int length = 0; length < massListScript.GetMassLengthSize();length++)
        {
            for(int side = 0;side < massListScript.GetMassSideSize(); side++)
            {
                GameObject obj = massListScript.GetMassObj();
                GameObject instanceobj = Instantiate(obj,pos,Quaternion.identity);
                MassStatus status = instanceobj.GetComponent<MassStatus>();
                status.SetMassNumber(number,length,side);
                massListScript.SetMassStatus(length,side,status);
                pos.x += 2;
                number++;
            }
            pos.y--;
            pos.x = instacePos.transform.position.x;
        }
    }

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


    public void MassRender(int playernum,int massnum)
    {
        MassStatus[,] massarry = massListScript.GetMassStatusArray();
        Debug.Log("マスを索敵");
        Debug.Log("マスの数字" + massnum.ToString());
        for (int length = 0; length < massListScript.GetMassLengthSize(); length++)
        {
            for (int side = 0; side < massListScript.GetMassSideSize(); side++)
            {
                if (massnum == massarry[length,side].GetMassNumber())
                {
                    Debug.Log("ヒット");
                    massarry[length, side].SetPlayerNumber(playernum);
                }
            }
        }
    }

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
}
