using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireSkill : Skill
{
    public void UseFireSkill()
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (isOnCooldown) return;
        
        StartCoroutine(CountDownCooldown());
        StartCoroutine(FirePowerUpPlayer());
        
    }

    private IEnumerator FirePowerUpPlayer()
    {
        PlayerManager.Instance.mainPlayer.playerFireUp.PlayerIsOnfire = true;
        Ball.Instance.photonView.RPC("InitBallFire", RpcTarget.All, (float) 5);
        yield return new WaitForSeconds(5);
        PlayerManager.Instance.mainPlayer.playerFireUp.PlayerIsOnfire = false;
    }
    
}

