////////////////////////////////////
//製作者　名越大樹
//クラス　サーバーとの通信に関するクラス
////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;

public class SocketStatus : MonoBehaviour
{
    public enum Status
    {
        None,
        Ini,
        Matching,
        Send,
        Recv,
        Close
    }
	
    ////////////////////////////////////////////
    //ソケットに関する変宣言数開始
    ////////////////////////////////////////////////
    [SerializeField]
    Status status;//ソケットの動作を設定する変数
    Socket sock;
    Socket connectsock;
    [SerializeField]
    int portnum;
    [SerializeField]
    string serverIPName;
    [SerializeField]
    SocketProcedure socketProcedureScript;
    IPAddress serverip;
    IPAddress localip;
    const string doneSymbol = "o";
    const char splitSymbol = '/';
    /////////////////////////////////////////////
    //ソケットに関する変数宣言終了
    /////////////////////////////////////////////

    /////////////////////////////////////////////
    //ゲームに関する変数宣言開始
    /////////////////////////////////////////////
    [SerializeField]
    GameMaster gameMasterScript;
    [SerializeField]
    PlayerStatus playerStatusScript;
    [SerializeField]
    MassAction massActionScript;
    bool isUpdate;
    [SerializeField]
    List<string> messageList = new List<string>();
    [SerializeField]
    GameUIManager uiManaerScript;
    [SerializeField]
    string sendData;
    int playerNumber;
    /////////////////////////////////////////////
    //ゲームに関する変数宣言終了
    /////////////////////////////////////////////

    void Start()
    {
        Thread thread = new Thread(Ini);
        thread.Start();
    }

    void Update()
    {
        MessageUpdate();
    }

    /// <summary>
    /// サーバーから受信したデータを処理する変数
    /// </summary>
    void MessageUpdate()
    {
        if (isUpdate)
        {
            while (messageList.Count != 0)
            {
                RecievConpornent(messageList[0]);
                messageList.RemoveAt(0);
            }
            isUpdate = false;
        }
    }

    void Ini()
    {
        SocketIni();
        socketProcedureScript.Connect(ref sock, serverip, portnum, ref connectsock);
        gameMasterScript.SetIsIni(true);
        status = Status.Ini;
        playerStatusScript.SetIsOnline(true);
        SocektUpdate();
    }

    /// <summary>
    /// ソケットの設定をする処理
    /// </summary>
    void SocketIni()
    {
        serverip = IPAddress.Parse(serverIPName);
        sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        sock.Blocking = true;
        sock.NoDelay = true;
        connectsock = null;
    }

    public void SetStatus(Status set)
    {
        status = set;
    }

    void SocektUpdate()
    {
        try
        {
            while (status != Status.Close)
            {
                switch (status)
                {
                    case Status.None:
                        break;

                    case Status.Ini:
                        Debug.Log("初期化開始");
                        ServerFromDataRecv();
                        DoneSend();
                        ServerFromDataRecv();
                        Debug.Log("初期化終了");
                        status = Status.None;
                        break;

                    case Status.Send:
                        Debug.Log("送信処理を開始します");
                        SendServerData();
                        Debug.Log("送信処理を開始します");
                        break;

                    case Status.Recv:
                        Debug.Log("受信処理を開始します");
                        ServerFromDataRecv();
                        status = Status.None;
                        Debug.Log("受信処理を終了します");
                        break;
                }
            }
            Debug.Log("ゲームがしゅうりょうしました。");
        }
        catch (Exception ex)
        {
            Debug.Log("エラーが検出されました");
            Debug.Log(ex);
            socketProcedureScript.Close(ref connectsock);
            socketProcedureScript.Close(ref sock);
        }
        socketProcedureScript.Close(ref connectsock);
        socketProcedureScript.Close(ref sock);
    }

    /// <summary>
    /// 受信が完了をしたことをサーバーに知らせる処理
    /// </summary>
    void DoneSend()
    {
        socketProcedureScript.Send(ref connectsock, doneSymbol);
    }

    /// <summary>
    /// サーバーからデータを受け取る処理
    /// </summary>
    void ServerFromDataRecv()
    {
        Debug.Log("データを受け取ります");
        string message = socketProcedureScript.Receive(ref connectsock);
        messageList.Add(message);
        isUpdate = true;
    }

    void RecievConpornent(string data)
    {
        Debug.Log("データを受け取りました");
        string[] splitdata = data.Split(splitSymbol);
        Debug.Log(splitdata[0]);

        switch (splitdata[0])
        {
            case "i"://スタート
                Debug.Log("初期化開始");
                RecievIni(splitdata);
                break;
            case "m"://マスを塗る
                Debug.Log("マスを塗ります");
                MassUpdate(splitdata);
                break;
            case "ip"://プレイヤーのナンバーをセット
                Debug.Log("プレイヤーのナンバーを書きます");
                SetPlayerNumber(splitdata);
                break;
            case "e"://ゲーム終了
                Debug.Log("ゲーム終了です。");
                PlayerMassCountSend();
                break;
            case "r"://ゲーム結果
                Debug.Log("ゲーム結果です。");
                DoneSend();
                ResultData(splitdata);
                status = Status.Close;
                break;
        }
    }

    /// <summary>
    /// プレイやーが塗った色の数を数える処理
    /// </summary>
    void PlayerMassCountSend()
    {
        int count = massActionScript.PlayerMassSumCount(playerNumber);
        Debug.Log("合計 =" + count.ToString());
        sendData = count.ToString() + splitSymbol;
        SendServerData();
        status = Status.Recv;
    }

    /// <summary>
    /// ゲームの勝敗に関する処理
    /// </summary>
    /// <param name="data"></param>
    void ResultData(string[] data)
    {
        int p1Count = int.Parse(data[1]);
        int p2Count = int.Parse(data[2]);
        uiManaerScript.ResultInformation(p1Count, p2Count);
        DoneSend();
    }

    /// <summary>
    /// プレイやーがアタッチしたマスをサーバーに送る処理
    /// </summary>
    /// <param name="length"></param>
    /// <param name="side"></param>
    void AttachMassSend(int length, int side)
    {
        string data = length.ToString() + splitSymbol + side.ToString();
        socketProcedureScript.Send(ref sock, data);
    }

    public void SetSendData(string set)
    {
        sendData = set;
    }

    /// <summary>
    /// サーバーにデータを送信する処理
    /// </summary>
    void SendServerData()
    {
        socketProcedureScript.Send(ref connectsock, sendData);
        sendData = "";
        status = Status.Recv;
    }

    /// <summary>
    /// プレイヤーのナンバーをセット
    /// </summary>
    /// <param name="data"></param>
    void SetPlayerNumber(string[] data)
    {
        int number = int.Parse(data[1]);
        playerNumber = number;
        playerStatusScript.SetPlayerNumber(number);
        if (number == 1)
        {
            uiManaerScript.UpdateInfoTurn(InformationUI.Status.MyTurn);
            playerStatusScript.SetIsTurn(true);
        }
        else
        {
            playerStatusScript.SetIsTurn(false);
            uiManaerScript.UpdateInfoTurn(InformationUI.Status.EnemyTurn);
            status = Status.Recv;
        }
        uiManaerScript.SetPlayerUI(number);
        playerStatusScript.SetIsOnline(true);
    }

    /// <summary>
    /// 初期化後の最初にサーバーから送られてくるデータの処理
    /// </summary>
    /// <param name="splitdata"></param>
    void RecievIni(string[] splitdata)
    {
        for (int index = 2; index <= 5; index++)//P1のマスのデータ
        {
            massActionScript.MassRender(1, int.Parse(splitdata[index]));
        }

        for (int index = 6; index < 9; index++)//P2のマスのデータ
        {
            massActionScript.MassRender(2, int.Parse(splitdata[index]));
        }
    }

    /// <summary>
    /// 相手がマスを塗った時に通る処理
    /// </summary>
    void MassUpdate(string[] splitdata)
    {
        int length = int.Parse(splitdata[1]);
        int side = int.Parse(splitdata[2]);
        int playernum = 0;
        switch (playerStatusScript.GetPlayerNumber())
        {
            case 1:
                playernum = 2;
                break;
            case 2:
                playernum = 1;
                break;
        }
        massActionScript.MassRender(playernum, length, side);
        UpdateInfoMassCount();
    }

    /// <summary>
    /// マスの情報を更新する処理
    /// </summary>
    void UpdateInfoMassCount()
    {
        int player1 = 0;
        int player2 = 0;
        massActionScript.PlayerMassCount(ref player1, ref player2, playerStatusScript.GetPlayerNumber());
        uiManaerScript.UpdateMassCount(player1, player2);
        int turn = playerStatusScript.GetTurn();
        if (playerStatusScript.GetPlayerNumber() == 1 && turn <= 0)
        {
            Debug.Log("ゲームが終わりました");
            status = Status.Recv;
            return;
        }
        status = Status.None;
        playerStatusScript.SetIsTurn(true);
        uiManaerScript.UpdateInfoTurn(InformationUI.Status.MyTurn);
    }
}
