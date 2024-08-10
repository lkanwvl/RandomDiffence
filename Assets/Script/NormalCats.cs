using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Enemy;

public class NormalCats : MonoBehaviour
{
    public static NormalCats instance;
    [SerializeField] TurretName turretName;
    [SerializeField] GameObject ammo;
    [SerializeField, Tooltip("공속")] float attackSpeed = 2f;
    private float shootCoolDown;
    float buffTime = 0;
    GameObject goEnemy;
    float CoolResetNum = 0;
    JsonLoader.cTower myTowerData;
    float slowValue = 0f;
    float damageUp;
    float fullPur;
    float nowPur;
    float stun;
    int multiple;

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
            damageUp = _value;
        }
        else if(power == "fullHpDamage")
        {
            fullPur = _value;
        }
        else if (power == "nowHpDamage")
        {
            nowPur = _value;
        }
        else if (power == "stun")
        {
            stun = _value;
        }
        else if (power == "multiple")
        {
            multiple = (int)_value;
        }
    }
    
    private void multiShoot(int _value)
    {
        switch (_value)
        {
            case 3:
                //Instantiate(ammo, transform.position, Quaternion.Angle(-15, 15); 여기부터
                return;
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
            goSc.SetAttack(damageUp);
            goSc.SetFull(fullPur);
            goSc.SetNow(nowPur);
            shootCoolDown = CoolResetNum - buffTime;
        }
    }

}
