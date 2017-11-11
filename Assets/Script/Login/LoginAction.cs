﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Net.Sockets;
using System.Net;
public class LoginAction : MonoBehaviour {

    [SerializeField]
    SocketClass socketScript;
    Socket sock;
    [SerializeField]
    LoginManager loginManagerScript;
    bool isLogin = false;
    [SerializeField]
    string userkey;
    [SerializeField]
    string idkey;
    // Update is called once per frame
    void Update()
    {
        Key();
    }


    void Key()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isLogin)
        {
            Debug.Log("hoge");
            isLogin = true;
            UserData();
        }
    }


    void UserData()
    {
      bool result =  loginManagerScript.GetHasKey(idkey);
        if(!result)
        {
            loginManagerScript.Rookie();
        }
    }


    void Host()
    {
        string addres = socketScript.GetHost();
    }

    public void SetisLogin(bool set)
    {
        isLogin = set;
    }
}