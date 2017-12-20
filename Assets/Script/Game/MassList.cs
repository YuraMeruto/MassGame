/////////////////////////////////////
//製作者　名越大樹
//クラス　ボード上のマスを管理するクラス
/////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassList : MonoBehaviour
{
    [SerializeField]
    int massLengthSize;
    [SerializeField]
    int massSideSize;
    MassStatus[,] massStatusArray= new MassStatus[6, 6];
    [SerializeField]
    GameObject massObj;

    public void SetMassStatus(int length,int side,MassStatus set)
    {
        massStatusArray[length, side] = set;
    }

    public MassStatus[,] GetMassStatusArray()
    {
        return massStatusArray;
    }

    public GameObject GetMassObj()
    {
        return massObj;
    }

    public int GetMassLengthSize()
    {
        return massLengthSize;
    }

    public int GetMassSideSize()
    {
        return massSideSize;
    }
}
