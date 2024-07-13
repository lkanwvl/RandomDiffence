using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCats : MonoBehaviour
{
    public class cTower
    {
        public string name;
        public int damage;
        public float attackSpeed;
        public cPower power;
        public List<string> mix;
    }
     
    public class cPower
    {
        public enumPower power;
        public enumPowerType powerType;
        public float value;
    }

    public enum enumPowerType
    {
        Percent,
        Sec,
    }

    public enum enumPower
    {
        multiple,
        slow,
        stun,
        damageUp,
        buff,
    }

    [SerializeField] GameObject ammo;
    [SerializeField] float shootCoolDown = 1f;
    GameObject goEnemy;
    float CoolResetNum = 0;

    private void Start()
    {
        CoolResetNum = shootCoolDown;

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
        if (shootCoolDown <= 0)
        {
            Instantiate(ammo, transform.position, Quaternion.identity);
            shootCoolDown = CoolResetNum;
        }
    }

}
