using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.EventSystems;

public class IceSkill : Skill
{
    public void UseIceSkill()
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (isOnCooldown) return;
        
        PlayerManager.Instance.enemyPlayer.photonView.RPC("FreezeOtherPlayer", RpcTarget.All);
    }


}
