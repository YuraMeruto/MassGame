using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
public class Matching : MonoBehaviour
{
    Socket sock;
    [SerializeField]
    int portnum;
    [SerializeField]
    string serverIPName;
    [SerializeField]
    SocketProcedure socketProcedureScript;
    IPAddress serverip;
    IPAddress localip;
    // Use this for initialization
    void Start()
    {
        Thread thread = new Thread(Login);
        thread.Start();
    }

    void Login()
    {
        //        string gethost = socketProcedureScript.GetHost();
        //        localip = IPAddress.Parse(gethost);
        serverip = IPAddress.Parse(serverIPName);
        sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        sock.NoDelay = true;
        sock.ReceiveTimeout = 500;
        Socket connectsock = null;
        socketProcedureScript.Connect(ref sock, serverip, portnum, ref connectsock);
        socketProcedureScript.Send(ref connectsock, "hogehoge");
        socketProcedureScript.Receive(ref connectsock);
        socketProcedureScript.Receive(ref connectsock);

        socketProcedureScript.Close(ref connectsock);
        socketProcedureScript.Close(ref sock);

    }
}
