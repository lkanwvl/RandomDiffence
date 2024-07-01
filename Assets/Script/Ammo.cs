using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] float ammoSpeed = 5.0f;
    GameObject goEnemy;


    private void Start()
    {
        goEnemy = GameObject.FindWithTag("Enemy");
    }

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * ammoSpeed;

        float angle = Quaternion.FromToRotation(Vector3.up, transform.position - goEnemy.transform.position).eulerAngles.z;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        if(goEnemy == null)
        {
            Destroy(gameObject);
        }
    }
}
