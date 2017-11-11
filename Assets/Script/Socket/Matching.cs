using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Net;
using System.Net.Sockets;
public class Matching : MonoBehaviour
{
    Socket sock;
    [SerializeField]
    int portnum;
    [SerializeField]
    string serverIPName;
    [SerializeField]
    SocketClass socketClassScript;
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
        string gethost = socketClassScript.GetHost();
        localip = IPAddress.Parse(gethost);
        serverip = IPAddress.Parse(serverIPName);
        sock = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
        socketClassScript.Connect(ref sock,serverip,portnum);

    }
}
