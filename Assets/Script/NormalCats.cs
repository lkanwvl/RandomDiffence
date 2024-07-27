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
        public float powerType;
        public float value;
    }
        
    public enum enumPower
    {
        slow,
        attackSpeed,
        damageUp,
        fullHpDamage,
        nowHpDanage,
        stun,
        multiple,
    }

    [SerializeField] GameObject ammo;
    [SerializeField, Tooltip("°ø¼Ó")] float attackSpeed = 2f;
    private float shootCoolDown;
    GameObject goEnemy;
    float CoolResetNum = 0;

    private void Start()
    {
        shootCoolDown = 1 / attackSpeed;
    }
    private void Update()
    {
        CoolResetNum = 1 / attackSpeed;
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
