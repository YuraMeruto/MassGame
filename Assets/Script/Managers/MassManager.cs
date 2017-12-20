////////////////////////////////////
//製作者　名越大樹
//クラス　ほかのマネージャークラスと中継をするクラス
////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassManager : MonoBehaviour
{
    [SerializeField]
    MassList massListScript;
    [SerializeField]
    MassAction massActionScript;
    [SerializeField]

    public void Ini()
    {
        massActionScript.Ini();
    }

    public bool MassRender(int playernumnber, int targetlength, int targetside)
    {
       return massActionScript.MassRender(playernumnber, targetlength, targetside);
    }

    public void PlayerMassCount(ref int p1, ref int p2, int playernum)
    {
        massActionScript.PlayerMassCount(ref p1, ref p2, playernum);
    }
}
