using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
public class Matching : MonoBehaviour
{
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
    [SerializeField]
    Text test;
    [SerializeField]
    GameMaster gameMasterScript;

    void Start()
    {
        Thread thread = new Thread(Ini);
        thread.Start();
    }

    void Update()
    {
        test.text = socketProcedureScript.TestMessage();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Thread testthread = new Thread(TestSend);
            testthread.Start();
        }
    }
    void Ini()
    {
        serverip = IPAddress.Parse(serverIPName);
        sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        sock.NoDelay = true;
        sock.ReceiveTimeout = 500;
        connectsock = null;
        socketProcedureScript.Connect(ref sock, serverip, portnum, ref connectsock);
        socketProcedureScript.Receive(ref connectsock);
        //        socketProcedureScript.Receive(ref connectsock);
        //        socketProcedureScript.Close(ref connectsock);
        //socketProcedureScript.Close(ref sock);

    }

    void TestSend()
    {
        socketProcedureScript.Send(ref connectsock, "hogehoge");
        socketProcedureScript.Close(ref connectsock);
        socketProcedureScript.Close(ref sock);
    }
}
