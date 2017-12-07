using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public enum Status
    {
        Ini,
        Send,
        Recv,
        End
    }
    Status status;
    bool isUpdate;
    [SerializeField]
    int count;
    public void RecvData(string data)
    {
        string[] spritdata = data.Split('/');
        string id = spritdata[0];
        isUpdate = true;
        switch (id)
        {
            case "s":
                status = Status.Ini;
                break;
            case "u":
                break;
            case "e":
                status = Status.End;
                break;
        }
    }
}
