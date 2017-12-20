///////////////////////////////////
//製作者　名越大樹
//クラス　プレイヤーの操作に関する処理
///////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField]
    PlayerStatus playerStatusScript;
    [SerializeField]
    PlayerManager playerManagerScript;

    void Update()
    {
        Mouse();
    }

    void Mouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MassRay();
        }
    }

    void MassRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mass = playerStatusScript.GetMassLayer();
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mass))
        {
            HitMass(hit.collider.gameObject);
        }
    }

    /// <summary>
    /// マスに当たったときの処理
    /// </summary>
    /// <param name="hit"></param>
    void HitMass(GameObject hit)
    {
        if (!playerStatusScript.GetIsTurn())
        {
            return;
        }
        MassStatus mass = hit.GetComponent<MassStatus>();
        if (mass == null)
        {
            return;
        }
        int length = 0, side = 0;
        mass.GetLengthSideNumber(ref length, ref side);
        bool result = playerManagerScript.MassRender(playerStatusScript.GetPlayerNumber(), length, side);
        if (result)
        {
            int player1 = 0;
            int player2 = 0;
            playerManagerScript.PlayerMassCount(ref player1, ref player2, playerStatusScript.GetPlayerNumber());
            SetData(length,side);
            playerManagerScript.UpdateMassCount(player1, player2);
        }
    }

    void SetData(int length, int side)
    {
        playerStatusScript.SubtractionTurn();
        if (playerStatusScript.GetIsOnline())
        {
            SetSendData(length, side);
        }
        playerStatusScript.SetIsTurn(false);
    }

    /// <summary>
    /// 塗ったマスの情報をセット
    /// </summary>
    /// <param name="length"></param>
    /// <param name="side"></param>
    void SetSendData(int length,int side)
    {
        string data = length.ToString() + "/" + side.ToString();
        playerManagerScript.SetSendData(data);
        playerManagerScript.SetStatus(SocketStatus.Status.Send);
    }
}
