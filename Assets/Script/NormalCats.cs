using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCats : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] float shootCoolDownOrigin = 0.5f;
    [SerializeField] float shootCoolDown = 0.5f;
    GameObject goEnemy;
    private void Awake()
    {
        
    }

    private void Start()
    {
    }

    private void Update()
    {
        goEnemy = GameObject.FindWithTag("Enemy");

        if (goEnemy != null)
        {
            shoot();
        }
    }

    private void shoot()
    {
        shootCoolDown -= Time.deltaTime;
        if(shootCoolDown <= 0)
        {
            Instantiate(ammo, transform.position, Quaternion.identity);
            shootCoolDown = shootCoolDownOrigin;
        }
    }

}
