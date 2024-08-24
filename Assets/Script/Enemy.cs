
using System.Collections.Generic;
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
    [SerializeField] double enemyHp;
    float stunTime;
    string turretName;
    float stun;

    List<string> listBeforeName = new List<string>();
    Transform trsTarget;
    LineManager lineManager;

    private void OnTriggerEnter2D(Collider2D collision)//�Ѿ� 
    {
        if(collision.tag == Tool.GetGameTag(GameTag.Ammo))
        {
            
            Ammo ammo = collision.GetComponent<Ammo>();
            
            enemyHp -= ammo.GetDamage() + ammo.GetAttack(ammo.GetDamage()) + ammo.GetFull(maxEnemyHp) + ammo.GetNow(enemyHp);
            if(nameCheck(ammo.GetName()) == false)
            {
                return;
            }
            stunTime = ammo.GetStun();
            if(stunTime > 0)
            {
                stun = 0;
            }
            else
            {
                stun = 1;
            }
            enemySpeed -= enemySpeed * ammo.GetSlow() * stun;
        }
    }
    
    private bool nameCheck(string _name)
    {
        turretName = _name;
        int count = listBeforeName.Count;
        for(int iNum = count - 1; iNum >= 0; --iNum)
        {
            if(listBeforeName[iNum] == turretName)
            {
                return false;
            }
        }
        listBeforeName.Add(turretName);
        return true;
    }

    private void Start()
    {
        listBeforeName.Clear();
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
        timer(stunTime);
    }
    private float timer(float _time)
    {
        _time -= Time.deltaTime;
        return _time;
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
