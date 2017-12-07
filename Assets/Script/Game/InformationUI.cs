using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InformationUI : MonoBehaviour
{

    [SerializeField]
    Text informaitonText;
    public enum Status
    {
        None,
        Your,
        My,
        End
    }
    [SerializeField]
    GameUIManager uiManagerScript;

    public void UpdateInfomation(Status status)
    {
        switch (status)
        {
            case Status.Your:
                informaitonText.text = "相手のターンです";
                break;
        }
    }
    public void Result(int p1, int p2)
    {
        string result = "";
        string wintext = "<color=red>YourWin</color>";
        string losetext = "<color=blue>YourLose</color>";
        if (uiManagerScript.GetPlayerNumber() == 1)
        {
            if (p1 <= p2)
            {
                informaitonText.text = losetext;
            }
            else
            {
                informaitonText.text = wintext;
            }
        }
        else
        {
            if (p1 <= p2)
            {
                informaitonText.text = wintext;
            }
            else
            {
                informaitonText.text = losetext;
            }
        }
    }
}
