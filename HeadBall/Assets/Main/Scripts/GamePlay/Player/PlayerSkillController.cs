using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            InGameUI.Instance.fireSkill.UseFireSkill();
        }
        
        if (Input.GetKey(KeyCode.F)) InGameUI.Instance.iceSkill.UseIceSkill();

    }
}
