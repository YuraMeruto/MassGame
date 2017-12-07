using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniManager : MonoBehaviour {

    [SerializeField]
    MassManager massManagerScript;
    public void Ini()
    {
        massManagerScript.Ini();
    }
}
