using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemySpeed = 5f;
    [SerializeField] int maxEnemyHp = 5;
    float enemyHp = 5f;
    [SerializeField] float bulletDamage = 1f;

    Transform trsTarget;
    LineManager lineManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Tool.GetGameTag(GameTag.Ammo))
        {
            enemyHp -= bulletDamage;
        }
    }

    private void Start()
    {
        lineManager = LineManager.Instance;
        trsTarget = lineManager.GetFirstTarget();
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
