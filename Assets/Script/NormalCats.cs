using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

public class NormalCats : MonoBehaviour
{
    public static NormalCats instance;
    [SerializeField] TurretName turretName;
    [SerializeField] GameObject ammo;
    [SerializeField, Tooltip("°ø¼Ó")] float attackSpeed = 2f;
    private float shootCoolDown;
    float buffTime = 0;
    GameObject goEnemy;
    float CoolResetNum = 0;
    JsonLoader.cTower myTowerData;
    float slowValue = 0f;
    private void Start()
    {
        myTowerData = JsonLoader.Instance.GetTowerData(turretName);
        attackSpeed = myTowerData.attackSpeed;
        shootCoolDown = 1 / attackSpeed;
        getPower();
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

    private void getPower()
    {
        int count = myTowerData.listPower.Count;
        for(int iNum = 0; iNum < count; ++iNum)
        {
            JsonLoader.enumPower power = myTowerData.listPower[iNum].power;
            float value = myTowerData.listPower[iNum].value;
            SpPower(power, value);
        }
    }


    private void SpPower(Enum _power, float _value)
    {
        string power = _power.ToString();
        if(power == "slow")
        {
            slowValue = _value;
        }
        else if(power == "attackSpeed")
        {
            buffTime = CoolResetNum * _value;
        }
        else if(power == "damageUp")
        {
            
        }
        else if(power == "fullHpDamage")
        {

        }
        else if (power == "nowHpDanage")
        {

        }
        else if (power == "stun")
        {

        }
        else if (power == "multiple")
        {

        }
    }

        
    private void shoot()
    {
        shootCoolDown -= Time.deltaTime;
        if (shootCoolDown <= 0)
        {
            GameObject go = Instantiate(ammo, transform.position, Quaternion.identity);
            Ammo goSc = go.GetComponent<Ammo>();
            goSc.SetDamage(myTowerData.damage);
            goSc.SetSlow(slowValue, myTowerData.name);
            shootCoolDown = CoolResetNum - buffTime;
        }
    }

}
