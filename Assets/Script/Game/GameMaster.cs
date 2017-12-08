using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    bool isIni = false;
    [SerializeField]
    bool isGame;
    [SerializeField]
    IniManager iniManaGerScript;

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
            iniManaGerScript.Ini();
            isIni = false;
            isGame = true;
        }
    }
}
