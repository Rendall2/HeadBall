using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected Image cooldownImg;
    protected bool isOnCooldown;
    protected float cooldown = 60;
    protected float remainingCooldown;

    void Awake()
    {
        remainingCooldown = cooldown;
    }

    protected IEnumerator CountDownCooldown()
    {
        isOnCooldown = true;
        cooldownImg.fillAmount = 0;
        while (remainingCooldown != 0)
        {
            yield return new WaitForSeconds(.2f);
            cooldownImg.fillAmount = 1 - remainingCooldown / cooldown;
            remainingCooldown -= .2f;
        }

        isOnCooldown = false;
    }
}
