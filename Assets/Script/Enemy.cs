using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemySpeed = 5f;
    float maxEnemyHp;
    float enemyHp;

    Transform trsTarget;
    LineManager lineManager;

    public enum TurretName
    {
        A1, A2, A3, A4, A5, A6, A7, A8,
        B1, B2, B3, B4, B5, B6, B7, B8, B9,
        C1, C2, C3, C4, C5, C6, C7, C8, C9,
        D1, D2, D3, D4, D5, D6, D7, D8, D9,
        E1, E2, E3, E4, E5, E6, E7, E8, E9,
        F1, F2, F3, F4, F5, F6, F7, F8, F9, F10,
    }

    private string enumToString(Enum _enum)
    {
        return $"{_enum}";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Tool.GetGameTag(GameTag.Ammo))
        {
            enemyHp -= bulletDamage(enumToString(TurretName.A1));
        }
    }

    private float bulletDamage(string _value)
    {
        switch (_value)
        {
            case "A1":
                return 48;
            case "A2":
                return 50;
            case "A3": 
                return 51;
            case "A4":
                return 53;
            case "A5":
                return 55;
            case "A6":
                return 56;
            case "A7":
                return 57;
            case "A8":
                return 58;
            case "B1":
                return 90;
            case "B2":
                return 75;
            case "B3":
                return 180;
            case "B4":
                return 105;
            case "B5":
                return 106;
            case "B6":
                return 107;
            case "B7":
                return 108;
            case "B8":
                return 109;
            case "B9":
                return 110;
            case "C1":
                return 300;
            case "C2":
                return 200;
            case "C3":
                return 500;
            case "C4":
                return 402;
            case "C5":
                return 403;
            case "C6":
                return 405;
            case "C7":
                return 408;
            case "C8":
                return 409;
            case "C9":
                return 410;
            case "D1":
                return 1555;
            case "D2":
                return 1700;
            case "D3":
                return 1560;
            case "D4":
                return 1670;
            case "D5":
                return 1980;
            case "D6":
                return 2115;
            case "D7":
                return 2234;
            case "D8":
                return 2411;
            case "D9":
                return 3500;
            case "E1":
                return 8000;
            case "E2":
                return 9650;
            case "E3":
                return 10200;
            case "E4":
                return 11200;
            case "E5":
                return 10500;
            case "E6":
                return 11200;
            case "E7":
                return 12000;
            case "E8":
                return 11500;
            case "E9":
                return 12400;
            case "F1":
                return 49800;
            case "F2":
                return 45600;
            case "F3":
                return 57000;
            case "F4":
                return 54621;
            case "F5":
                return 57814;
            case "F6":
                return 56218;
            case "F7":
                return 58941;
            case "F8":
                return 51478;
            case "F9":
                return 53481;
            case "F10":
                return 56842;

        }
        return -1;
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
