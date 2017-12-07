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

    public string GetHost()
    {
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress hostadress = host.AddressList[0];
        return host.HostName.ToString();
    }

    public void Connect(ref Socket sock, IPAddress ip, int port, ref Socket connectsock)
    {
        Debug.Log("コネクト開始");
        sock.Connect(ip, port);
        connectsock = sock;
        Debug.Log(sock.RemoteEndPoint);
        Debug.Log("コネクトしました");
        if(sock.Connected)
        {
            test = "接続できました";
        }

        else
        {
            test = "接続できませんでした";
        }
    }

    public Socket Accept(ref Socket sock)
    {
        Socket result = sock.Accept();
        Debug.Log("Acceptしました。");
        return result;
    }

    public bool Send(ref Socket sock, string message)
    {
        byte[] sendbyte = Encoding.UTF8.GetBytes(message);
        sock.SendTimeout = 1000;
        int result = sock.Send(sendbyte, 0, sendbyte.Length, SocketFlags.None);
        Debug.Log("現在のソケットの状況" + sock);
        Array.Clear(sendbyte, 0, sendbyte.Length);
        sock.SendBufferSize = 0;
        Debug.Log("送信完了です.");
        Debug.Log("送信の結果 = " + result);
        return true;
    }

    public string Receive(ref Socket sock)
    {
        int result = -2;
        Debug.Log("受信開始");
        Debug.Log(sock.AddressFamily);
        //        sock.Receive(recievebyte);
        try {
            result = sock.Receive(recievebyte, 0, recievebyte.Length, SocketFlags.None);
        }
        catch (Exception ex)
        {
            Debug.Log("受信失敗");
            Debug.Log(ex.Message);
        }
        Debug.Log(result);
        Debug.Log("現在のソケットの状況 = " + sock);
        string message = Encoding.UTF8.GetString(recievebyte);
        Array.Clear(recievebyte, 0, recievebyte.Length);
        Debug.Log("メッセージを受信しました。");
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
}
