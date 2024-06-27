using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;
    [SerializeField] GameObject black;
    [SerializeField] GameObject timeNums;
    bool timeNumsHas;
    [SerializeField] GameObject goldMix;
    bool goldMixHas;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        if(Tool.isEnterFirstScene == false)
        {
            SceneManager.LoadSceneAsync("MainScene");
        }
        timeNumsHas = false;
        goldMixHas = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        tutorialClicker();
        spawnEnemy();
    }
    

    private void tutorialClicker()
    {
        if (Input.GetMouseButtonDown(0) && timeNumsHas == true && goldMixHas == false)
        {
            timeNums.SetActive(false);
            goldMix.SetActive(true);
            goldMixHas = true;
        }
        if (Input.GetMouseButtonDown(0) && timeNumsHas == false)
        {
            timeNums.SetActive(true);
            timeNumsHas = true;
        }
    }


    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnPoint;
    private void spawnEnemy()
    {
        float time = 1;
        time -= Time.deltaTime;
        if(time <= 0)
        {
            Instantiate(enemy, spawnPoint);
        }
        if(time <= 0)
        {
            time = 1;
        }
    }
    //[SerializeField] float enemySpeed = 5f;
    //Vector3 moveDir;
    //private void enemyMove()
    //{
    //    moveDir.y = enemySpeed * Time.deltaTime;
    //    //enemy.transform.position += moveDir;
    //    //if(enemy.transform.position.y >= )

    //    enemy.transform.position = Vector3.MoveTowards(transform.position, 格利瘤, 加档);
    //    if(Vector3.Distance(enemy.transform.position, 格利瘤) == 0)
    //}
}
