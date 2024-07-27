using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JsonLoader : MonoBehaviour
{
    public static JsonLoader Instance;

    [SerializeField] TextAsset towerText;
    [Serializable]
    public class cTower
    {
        public string name;
        public int damage;
        public float attackSpeed;
        public List<cPower> listPower = new List<cPower>();
        public List<string> listMix = new List<string>();
    }
    public class cPower
    {
        public enumPower power;
        public float value;
    }
    public enum enumPower
    {
        slow,
        attackSpeed,
        damageUp,
        fullHpDamage,
        nowHpDamage,
        stun,
        multiple,
    }

    List<cTower> listTowerData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;   
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        string dataValue = towerText.ToString();
        listTowerData = JsonConvert.DeserializeObject<List<cTower>>(dataValue);
    }

    public cTower GetTowerData(TurretName _turretName)
    {
        string findName = _turretName.ToString();
        return listTowerData.Find(x => x.name == findName);
    }
}
