using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected Image cooldownImg;
    private bool isOnCooldown;
    protected int cooldown = 60;
    protected int remainingCooldown;

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
            yield return new WaitForSeconds(1);
            cooldownImg.fillAmount = (1 - remainingCooldown) / cooldown;
            remainingCooldown -= 1;
        }

        isOnCooldown = false;
    }

    protected virtual void UseSkill()
    {
        if (isOnCooldown) return;
        StartCoroutine(CountDownCooldown());
        EventSystem.current.SetSelectedGameObject(null);
    }
}
