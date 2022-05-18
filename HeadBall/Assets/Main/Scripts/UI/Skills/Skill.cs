using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected Image cooldownImg;
    protected bool isOnCooldown;
    protected float cooldown = 6;
    protected float remainingCooldown;
    

    protected IEnumerator CountDownCooldown()
    {
        isOnCooldown = true;
        remainingCooldown = cooldown;
        cooldownImg.fillAmount = 0;
        while (remainingCooldown >= 0)
        {
            yield return new WaitForSeconds(.2f);
            remainingCooldown -= .2f;
            cooldownImg.fillAmount = 1 - remainingCooldown / cooldown;
        }

        isOnCooldown = false;
    }
}
