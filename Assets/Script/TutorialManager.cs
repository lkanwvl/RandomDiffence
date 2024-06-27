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
    [SerializeField] GameObject TutorialUi;

    [Header("<color=red>Àû</color> °ü·Ã")]
    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnPoint;
    float time = 1;
    int enemySpawnNumber;
    [SerializeField] int maxEnemySpawnNumber;

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
        TutorialUi.SetActive(true);
    }

    void Update()
    {
        tutorialClicker();
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

    private void spawnEnemy()
    {
        if (enemySpawnNumber == maxEnemySpawnNumber) return;
        time -= Time.deltaTime;
        if(time <= 0)
        {
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
            time = 1;
            enemySpawnNumber++;
        }
    }

    private void roundStart()
    {
        enemySpawnNumber = 0;
    }


}
