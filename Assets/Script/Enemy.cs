using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemySpeed = 5f;

    Transform trsTarget;
    LineManager lineManager;

    private void Start()
    {
        lineManager = LineManager.Instance;
        trsTarget = lineManager.GetFirstTarget();
    }

    void Update()
    {
        enemyMove();
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
