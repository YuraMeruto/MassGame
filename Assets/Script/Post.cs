//////////////////////////////////
//製作者　名越大樹
//クラス　サーバーにリクエストするクラス
//////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Post : MonoBehaviour
{
    public enum Status
    {
        None,
        Sucsess,
        Failled,
        Error
    }
    [SerializeField]
    Status status = Status.None;
    string serverUrl;
    float timeOut;
    [SerializeField]
    string responseMeesage;

    public Status GetStatus()
    {
        return status;
    }

    public void PostRequest(Dictionary<string, string> data, float time, string url)
    {
        serverUrl = url;
        timeOut = time;
        StartCoroutine(PostRequestSend(data));
    }

    IEnumerator PostRequestSend(Dictionary<string, string> data)
    {
        Debug.Log("送信now");
        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string, string> array in data)
        {
            form.AddField(array.Key, array.Value);
        }
        WWW www = new WWW(serverUrl, form);
        yield return StartCoroutine(CheckResponse(www, timeOut));
        if (www.error != null)
        {
            status = Status.Error;
            Debug.Log(www.error);
        }

        else
        {
            Debug.Log("成功now");
            responseMeesage = www.text;
            status = Status.Sucsess;
            yield return www.text;
        }
    }

    IEnumerator CheckResponse(WWW www, float time)
    {
        while (!www.isDone)
        {
            if (timeOut < 0.0f)
            {
                yield return null;
            }
            time -= Time.deltaTime;
        }
    }

    public string GetResponse()
    {
        return responseMeesage;
    }

}
