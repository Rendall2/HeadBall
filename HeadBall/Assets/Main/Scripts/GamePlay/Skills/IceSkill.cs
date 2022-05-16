using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class IceSkill : Skill
{
    protected override void UseSkill()
    {
        base.UseSkill();
        PlayerManager.Instance.enemyPlayer.photonView.RPC("FreezeOtherPlayer", RpcTarget.Others);

        FreezeOtherPlayer();
        
    }

    [PunRPC]
    private void FreezeOtherPlayer()
    {
        PlayerManager.Instance.mainPlayer.playerMovement.enabled = false;
    }
}
