/////////////////////////////////////////////
//製作者　名越大樹
//クラス　ソケットの動作に関するクラス
/////////////////////////////////////////////

using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System;
public class SocketProcedure : MonoBehaviour
{
    public enum LogStatus
    {
        Bind,
        Accept,
        Connect,
        Send,
        Recv
    }
    string test;
    byte[] recievebyte = new byte[1000];

    public void Bind(ref Socket sock, IPEndPoint endpoint)
    {
        sock.Bind(endpoint);
        Debug.Log("バインドしました");
    }

    public void Listen(ref Socket sock, int backlog)
    {
        sock.Listen(backlog);
        Debug.Log("Listenしました");
    }

    /// <summary>
    /// ローカルアドレスを取得
    /// </summary>
    /// <returns></returns>
    public string GetHost()
    {
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress hostadress = host.AddressList[0];
        return host.HostName.ToString();
    }

    public void Connect(ref Socket sock, IPAddress ip, int port, ref Socket connectsock)
    {
        LogStart(ref sock, LogStatus.Connect);
        sock.Connect(ip, port);
        connectsock = sock;
        Debug.Log(sock.RemoteEndPoint);
        LogEnd(ref sock, LogStatus.Connect);
        if (connectsock.Connected)
        {
            Debug.Log("接続成功");
        }
    }

    public Socket Accept(ref Socket sock)
    {
        LogStart(ref sock, LogStatus.Accept);
        Socket result = sock.Accept();
        LogEnd(ref sock, LogStatus.Accept);
        return result;
    }

    public bool Send(ref Socket sock, string message)
    {
        byte[] sendbyte = Encoding.UTF8.GetBytes(message);
        sock.SendTimeout = 1000;
        int result = 0;
        LogStart(ref sock, LogStatus.Send);
        try
        {
             result = sock.Send(sendbyte, 0, sendbyte.Length, SocketFlags.None);
        }
        catch(Exception ex)
        {
            ErrorLog(ex,LogStatus.Send);
            sock.Close();
        }
        Array.Clear(sendbyte, 0, sendbyte.Length);
        sock.SendBufferSize = 0;
        LogEnd(ref sock, LogStatus.Send);
        Debug.Log("送信の結果 = " + result);
        return true;
    }

    public string Receive(ref Socket sock)
    {
        int result = -2;
        LogStart(ref sock, LogStatus.Recv);
        try
        {
            result = sock.Receive(recievebyte, 0, recievebyte.Length, SocketFlags.None);
        }
        catch (Exception ex)
        {
            ErrorLog(ex,LogStatus.Recv);
        }
        LogEnd(ref sock, LogStatus.Recv);
        string message = Encoding.UTF8.GetString(recievebyte);
        Array.Clear(recievebyte, 0, recievebyte.Length);
        Debug.Log("メッセージ内容 = " + message);
        return message;
    }

    public void Close(ref Socket sock)
    {
        sock.Shutdown(SocketShutdown.Both);
        sock.Close();
        sock = null;
        Debug.Log("ソケットを閉じました");
    }

    public string TestMessage()
    {
        return test;
    }

    void ErrorLog(Exception ex, LogStatus status)
    {
        Debug.Log(ex.Message);
    }
    void LogStart(ref Socket sock, LogStatus status)
    {
        Debug.Log("現在のソケットの状況" + sock);
        switch (status)
        {
            case LogStatus.Send:
                Debug.Log("送信開始です");
                break;

            case LogStatus.Recv:
                Debug.Log("受信開始です");
                break;

            case LogStatus.Bind:
                Debug.Log("バインド開始です");
                break;

            case LogStatus.Connect:
                Debug.Log("コネクト開始です");
                break;

            case LogStatus.Accept:
                Debug.Log("アクセプト開始です");
                break;
        }
    }

    void LogEnd(ref Socket sock, LogStatus status)
    {
        Debug.Log("現在のソケットの状況" + sock);
        switch (status)
        {
            case LogStatus.Send:
                Debug.Log("送信終了です");
                break;
            case LogStatus.Recv:
                Debug.Log("受信終了です");
                break;
            case LogStatus.Bind:
                Debug.Log("バインド終了です");
                break;
            case LogStatus.Connect:
                Debug.Log("コネクト終了です");
                break;
            case LogStatus.Accept:
                Debug.Log("アクセプト終了です");
                break;
        }
    }
}
