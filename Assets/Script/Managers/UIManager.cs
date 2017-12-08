///////////////////////////////////////
//製作者　名越大樹
//クラス　ログインに関するクラス
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    [SerializeField]
    GameObject UserNameEnter;
    [SerializeField]
    GameObject OKButton;
    [SerializeField]
    Post postScript;
    [SerializeField]
    string url;
    [SerializeField]
    float requestTime;

    public void SetActiveUI(bool set)
    {
        UserNameEnter.SetActive(set);
        OKButton.SetActive(set);
    }

    public void PostRequest(Dictionary<string, string> data)
    {
        postScript.PostRequest(data, requestTime, url);
    }
    public Post.Status GetPostStatus()
    {
        return postScript.GetStatus();
    }
}
