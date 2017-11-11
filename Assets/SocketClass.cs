using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System;
public class SocketClass : MonoBehaviour
{

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

    public void Connect(ref Socket sock, IPAddress ip, int port)
    {
        sock.Connect(ip, port);
        Debug.Log("コネクトしました");
    }

    public void Accept(ref Socket sock)
    {
        sock.Accept();
        Debug.Log("Acceptしました。");
    }

    public bool Send(ref Socket sock, string message)
    {
        byte[] sendbyte = Encoding.UTF8.GetBytes(message);
        sock.Send(sendbyte, 0, sendbyte.Length, SocketFlags.None);
        Debug.Log("送信完了です.");
        return true;
    }

    public string Receive(ref Socket sock)
    {
        int result = 0;
        while (result > 0)
        {
            result = sock.Receive(recievebyte, 0, recievebyte.Length, SocketFlags.None);
        }
        string message = Encoding.UTF8.GetString(recievebyte);
        Array.Clear(recievebyte, 0, recievebyte.Length);
        Debug.Log("メッセージを受信しました。");
        return message;
    }
}
