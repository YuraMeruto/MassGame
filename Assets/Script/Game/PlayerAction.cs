using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{

    [SerializeField]
    PlayerStatus playerStatusScript;
    [SerializeField]
    PlayerManager playerManagerScript;
    // Update is called once per frame
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
            playerStatusScript.SubtractionTurn();
            if(playerStatusScript.GetIsOnline())
            {
                SetSendData(length, side);
            }
            playerStatusScript.SetIsTurn(false);
        }
    }

    void SetSendData(int length,int side)
    {
        string data = length.ToString() + "/" + side.ToString();
        playerManagerScript.SetSendData(data);
        playerManagerScript.SetIsAction(true);
        playerManagerScript.SetStatus(SocketStatus.Status.Send);
    }
}
