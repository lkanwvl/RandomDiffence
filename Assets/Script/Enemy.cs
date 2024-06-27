using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemySpeed = 5f;
    [SerializeField] List<Transform> listCornor;


    private void Awake()
    {
        
    }

    void Update()
    {
        enemyMove();
    }



        int a = 0;
    private void enemyMove()
    {
        if (Vector3.Distance(transform.position, LineManager.instance.GetNextTarget(listCornor[a]).position) == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, LineManager.instance.GetNextTarget(listCornor[a]).position, enemySpeed);
            a += 1;
        }
    }

}
