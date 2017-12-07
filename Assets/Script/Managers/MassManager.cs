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
}
