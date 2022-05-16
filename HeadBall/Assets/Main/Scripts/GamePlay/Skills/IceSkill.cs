using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class IceSkill : Skill
{
    protected override void UseSkill()
    {
        base.UseSkill();
        FreezeOtherPlayer();
        
    }

    [PunRPC]
    private void FreezeOtherPlayer()
    {
        this..RPC()
    }
}
