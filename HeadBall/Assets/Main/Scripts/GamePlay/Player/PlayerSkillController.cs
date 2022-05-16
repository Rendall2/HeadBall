using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) InGameUI.Instance.fireSkill.UseFireSkill();
    }
}
