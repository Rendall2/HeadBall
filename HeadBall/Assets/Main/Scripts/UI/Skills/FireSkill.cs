using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class FireSkill : Skill
{
    protected override void UseSkill()
    {
        base.UseSkill();
        StartCoroutine(FirePowerUpPlayer());
        
    }

    private IEnumerator FirePowerUpPlayer()
    {
        PlayerManager.Instance.mainPlayer.playerFireUp.PlayerIsOnfire = true;
        PlayerManager.Instance.mainPlayer.photonView.RPC("Ball.Instance.InitBallFire(5)", RpcTarget.All);
        yield return new WaitForSeconds(5);
        PlayerManager.Instance.mainPlayer.playerFireUp.PlayerIsOnfire = false;
    }
}

