////////////////////////////////////
//製作者　名越大樹
//クラス　セーブとロードに関する処理
////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPlayerPref : MonoBehaviour
{
    public bool GetHasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public string GetStringKey(string key)
    {
        return PlayerPrefs.GetString(key);
    }
}
