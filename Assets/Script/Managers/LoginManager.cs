using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager : MonoBehaviour
{

    [SerializeField]
    ReadPlayerPref readPlayerPlefScript;
    [SerializeField]
    UIManager UIManagerScript;

    public bool GetHasKey(string key)
    {
        return readPlayerPlefScript.GetHasKey(key);
    }

    public string GetStringKey(string key)
    {
        return readPlayerPlefScript.GetStringKey(key);
    }

    public void Rookie()
    {
        UIManagerScript.SetActiveUI(true);
    }
}
