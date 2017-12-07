using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour {

    [SerializeField]
    Image playerUI;
    [SerializeField]
    Text playeUIText;
    [SerializeField]
    Text trunText;

    public void SetPlayerUI(int player)
    {
        switch (player)
        {
            case 1:
                playerUI.color = Color.blue;
                break;
            case 2:
                playerUI.color = Color.red;
                break;
        }
    }

    public void SetTurn(string turn)
    {
        trunText.text = "残りターン数「" + turn + "」です";
    }
}
