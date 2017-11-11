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
