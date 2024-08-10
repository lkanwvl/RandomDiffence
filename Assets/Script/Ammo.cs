using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField, Tooltip("Åº¼Ó")] float ammoSpeed = 5.0f;
    GameObject goEnemy;
    private float damage;
    private float slow;
    bool slowed = false;
    string slowName;
    string beforeName;
    private float attack;
    float stun;
    int multi;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == Tool.GetGameTag(GameTag.Enemy))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        goEnemy = GameObject.FindWithTag("Enemy");

        transform.position -= transform.up * Time.deltaTime * ammoSpeed;
        if( goEnemy != null )
        {
            float angle = Quaternion.FromToRotation(Vector3.up, transform.position - goEnemy.transform.position).eulerAngles.z;

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetFull(float _damage)
    {
        damage = _damage;
    }

    public float GetFull()
    {
        return damage;
    }

    public void SetStun(float _stun)
    {
        stun = _stun;
    }

    public float GetStun()
    {
        return stun;
    }

    public void SetNow(float _damage)
    {
        damage = _damage;
    }

    public float GetNow()
    {
        return damage;
    }

    public void SetDamage(float _damage)
    {
        damage = _damage; 
    }

    public float GetDamage()
    {
        return damage;
    }

    public void SetAttack(float _attack)
    {
        attack = _attack;
    }

    public float GetAttack()
    {
        return attack + 1;
    }

    public void SetSlow(float _slow, string _name)
    {
        slow = _slow;
        slowName = _name;
    }

    public string GetName()
    {
        return slowName;
    }

    public float GetSlow()
    {
        return slow;
    }
}
