using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField, Tooltip("Åº¼Ó")] float ammoSpeed = 5.0f;
    GameObject goEnemy;

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
}
