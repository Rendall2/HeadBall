using System.Collections;
using System.Collections.Generic;
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
        StartCoroutine(Ball.Instance.OpenBallFire(5));
        yield return StartCoroutine(Ball.Instance.MakeBallInFire(5));
        PlayerManager.Instance.mainPlayer.playerFireUp.PlayerIsOnfire = false;
    }
}

