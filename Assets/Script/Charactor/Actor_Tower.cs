using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor_Tower : Actor
{
    float time = 1;
    float IdleTime;
    Skill_Far skillFar;
    [SerializeField] GameObject skillMgr;

    private void Awake()
    {
        skillFar = skillMgr.GetComponent<Skill_Far>();
        IdleTime = time;
    }

    private void Update()
    {
        attack();
        time -= Time.deltaTime;
    }

    private void attack()
    {
        if (time <= IdleTime)
        {
            

            time = IdleTime;
        }
    }
}
