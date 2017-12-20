/////////////////////////////////////
//製作者　名越大樹
//クラス　ゲーム開始時に最初に行う処理を管理するクラス
/////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniManager : MonoBehaviour
{
    [SerializeField]
    MassManager massManagerScript;

    public void Ini()
    {
        massManagerScript.Ini();
        Destroy(gameObject);
    }
}
