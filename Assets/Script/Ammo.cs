
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField, Tooltip("Åº¼Ó")] float ammoSpeed = 5.0f;
    GameObject goEnemy;
    private float damage;
    private float fullDamage;
    private float nowDamage;
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







    public void SetDamage(float _damage)
    {
        damage = _damage; 
    }

    public void SetFull(float _damage)
    {
        fullDamage = _damage;
    }

    public void SetNow(float _damage)
    {
        nowDamage = _damage;
    }

    public void SetAttack(float _attack)
    {
        attack = _attack;
    }

    public void SetStun(float _stun)
    {
        stun = _stun;
    }

    public void SetSlow(float _slow, string _name)
    {
        slow = _slow;
        slowName = _name;
    }






    public float GetDamage()
    {
        return damage;
    }

    public float GetFull(float _value)
    {
        return _value * (fullDamage / 100);
    }


    public double GetNow(double _value)
    {
        return _value * (nowDamage / 100);
    }

    public float GetAttack(float _value)
    {
        return _value * (attack / 100);
    }

    public float GetStun()
    {
        return stun;
    }

    public float GetSlow()
    {
        return slow;
    }

    public string GetName()
    {
        return slowName;
    }
}
