using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Actor_Player : Actor
{
    Rigidbody rigid;
    Skill skill;
    [SerializeField] float speed;
    Vector3 MoveDir = Vector3.zero;
    private void Awake()
    {
        skill = GetComponent<Skill>();
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Move();
        if(Input.GetMouseButtonDown(0))
        {
            skill.SkillPlay(eSkill.Normal_Near);
        }
    }
    void Move()
    {
        MoveDir.x = Input.GetAxisRaw("Horizontal");
        MoveDir.z = Input.GetAxisRaw("Vertical");
        rigid.velocity = MoveDir * speed;
    }

}
