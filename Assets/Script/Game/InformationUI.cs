using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InformationUI : MonoBehaviour
{
    [SerializeField]
    Text informaitonText;
    [SerializeField]
    Text massInfoText;
    [SerializeField]
    GameUIManager uiManagerScript;
    public enum Status
    {
        MyTurn,
        EnemyTurn
    }
    /// <summary>
    /// ターンを表示させる処理
    /// </summary>
    /// <param name="status"></param>
    public void UpdateInfoTurn(Status status)
    {
        switch (status)
        {
            case Status.EnemyTurn:
                informaitonText.text = "相手のターンです";
                break;
            case Status.MyTurn:
                informaitonText.text = "あなたのターンです";
                break;
        }
    }

    /// <summary>
    /// プレイヤーの塗ったマスを表示する処理
    /// </summary>
    /// <param name="p1masscount"></param>
    /// <param name="p2masscount"></param>
    public void UpdateMassCount(int p1masscount, int p2masscount)
    {
        massInfoText.text = p1masscount.ToString() + ":" + p2masscount.ToString();
    }

    /// <summary>
    /// ゲームの勝敗を表示する処理
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
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
