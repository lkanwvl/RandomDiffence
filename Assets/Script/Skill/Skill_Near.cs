using System;
using UnityEngine;

public class Skill_Near : Skill
{
    public override void SkillPlay(Enum _e)
    {
        switch(_e)
        {
            case eSkill.Normal_Near:
                Debug.Log("∆Ú≈∏");
            break;
        }
    }
}
