using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Actor_Enemy : Actor
{
    Vector3 moveDir = new Vector3 (0, 0, -1);
    [SerializeField] float speed;
    void Update()
    {
        transform.Translate(moveDir * Time.deltaTime * speed, Space.World);
    }
}