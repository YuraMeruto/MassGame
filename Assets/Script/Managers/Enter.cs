using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class Enter : MonoBehaviour
{
    [SerializeField]
    Text userNameText;
    [SerializeField]
    UIManager uiManagerScript;
    public void EnterButton()
    {
        if (userNameText.text == "")
        {
            Debug.Log("失敗");
            return;
        }
        DataSet();
    }

    void DataSet()
    {
        Debug.Log("ルーキー");
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("name",userNameText.text);
        data.Add("status",1.ToString());
        uiManagerScript.PostRequest(data);
        Thread request = new Thread(ThreadPostRequest);
        request.Start();
    }

    void ThreadPostRequest()
    {

        while(uiManagerScript.GetPostStatus() == Post.Status.None)
        {
            
        }
        Debug.Log("成功");
    }
}
