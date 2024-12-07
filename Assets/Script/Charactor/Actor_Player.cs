using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Actor_Player : Actor
{
    Rigidbody rigid;
    Skill_Near skillNear;
    float gravity = -9.81f;
    [SerializeField] float speed;
    [SerializeField] GameObject skillMgr;
    [SerializeField] Transform playerCam;
    Vector3 MoveDir = Vector3.zero;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        skillNear = skillMgr.GetComponent<Skill_Near>();
    }
    private void Update()
    {
        Move();
        if(Input.GetMouseButtonDown(0))
        {
            skillNear.SkillPlay(eSkill.Normal_Near);
        }
    }
    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        float vertical = Input.GetAxisRaw("Vertical");

        MoveDir = new Vector3(horizontal, 0f, vertical);

        MoveDir = MoveDir.normalized;

        Vector3 cameraForward = playerCam.forward;
        Vector3 cameraRight = playerCam.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        MoveDir = MoveDir.z * cameraForward + MoveDir.x * cameraRight;

        transform.Translate(MoveDir * speed * Time.deltaTime, Space.World);
    }
}
