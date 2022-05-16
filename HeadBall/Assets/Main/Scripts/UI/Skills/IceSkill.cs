using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class IceSkill : Skill
{
    public  void UseIceSkill()
    {
        PlayerManager.Instance.enemyPlayer.photonView.RPC("FreezeOtherPlayer", RpcTarget.Others);
    }


}
