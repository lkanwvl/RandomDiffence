using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Actor_Enemy : Actor
{
    Vector3 moveDir = new Vector3 (0, 0, -1);
    [SerializeField] float speed;


    private void Awake()
    {
       PlayCharactor(eCharacter.Monster);
    }
    void Update()
    {

    }

    void move()
    {
        transform.Translate(moveDir * Time.deltaTime * speed, Space.World);
    }

    void ai(Enum _e)
    {
        switch(_e)
        {
            case eEnemy.Idle :
                move();
            break;

            case eEnemy.Attack : 

            break;
        }
    }


}