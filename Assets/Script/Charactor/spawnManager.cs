using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnList = new List<GameObject>();
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnTime = 1;
    float time;
    void Start()
    {
        time = spawnTime;   
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0)
        {
            spawn();
            timeReset();
        }
    }

    private void spawn()
    {
        int random = Random.Range(0, spawnList.Count);
        Instantiate(enemy, spawnList[random].transform.position, Quaternion.identity);
    }

    private void timeReset()
    {
        spawnTime = time;
    }
}
