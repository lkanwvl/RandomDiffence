using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum TurretName
{
    A1, A2, A3, A4, A5, A6, A7, A8,
    B1, B2, B3, B4, B5, B6, B7, B8, B9,
    C1, C2, C3, C4, C5, C6, C7, C8, C9,
    D1, D2, D3, D4, D5, D6, D7, D8, D9,
    E1, E2, E3, E4, E5, E6, E7, E8, E9,
    F1, F2, F3, F4, F5, F6, F7, F8, F9, F10,
}

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemySpeed = 5f;
    float maxEnemyHp;
    float enemyHp;
    string turretName;
    string beforeName;
    Transform trsTarget;
    LineManager lineManager;

    private void OnTriggerEnter2D(Collider2D collision)//ÃÑ¾Ë 
    {
        if(collision.tag == Tool.GetGameTag(GameTag.Ammo))
        {
            Ammo ammo = collision.GetComponent<Ammo>();
            
            enemyHp -= ammo.GetDamage();
            if(nameCheck(ammo.GetName()) == false)
            {
                return;
            }
            enemySpeed -= enemySpeed * ammo.GetSlow();
        }
    }
    
    private bool nameCheck(string _name)
    {
        beforeName = turretName;
        turretName = _name;
        if(beforeName == turretName)
        {
            return false;
        }
        return true;
    }

    private void Start()
    {
        roundForEnemyHp();
        lineManager = LineManager.Instance;
        trsTarget = lineManager.GetFirstTarget();
    }

    private void roundForEnemyHp()
    {
        maxEnemyHp += 100 * Mathf.Pow(1.2f, TutorialManager.instance.roundCount);
        enemyHp = maxEnemyHp;
    }

    void Update()
    {
        enemyMove();
        if(enemyHp <= 0)
        {
            Destroy(gameObject);
            TutorialManager.instance.KillEnemy();
        }
    }

    private void enemyMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, trsTarget.position, enemySpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, trsTarget.position) == 0)
        {
            trsTarget = lineManager.GetNextTarget(trsTarget);
        }
    }

}
