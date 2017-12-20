////////////////////////////////
//製作者　名越大樹
//クラス　ゲーム全体を管理するクラス
/////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    bool isIni = false;
    [SerializeField]
    bool isGame;
    [SerializeField]
    IniManager iniManagerScript;

    public void SetIsGame(bool set)
    {
        isGame = set;
    }

    public void SetIsIni(bool set)
    {
        isIni = set;
    }
        
    void Update()
    {
        if (isIni)
        {
            Debug.Log("生成開始");
            iniManagerScript.Ini();
            isIni = false;
            isGame = true;
        }
    }
}
