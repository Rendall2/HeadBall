using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("rrr");
            InGameUI.Instance.fireSkill.UseFireSkill();
        }
    }
}
