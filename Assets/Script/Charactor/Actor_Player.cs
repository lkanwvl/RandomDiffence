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
    void Awake()
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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        MoveDir = new Vector3(horizontal, 0f, vertical);

        if (MoveDir.magnitude > 1f)
            MoveDir = MoveDir.normalized;
    }

}
