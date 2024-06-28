using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;
    [SerializeField] GameObject black;
    [SerializeField] GameObject timeNums;
    bool timeNumsHas;
    [SerializeField] GameObject goldMix;
    bool goldMixHas;
    [SerializeField] GameObject TutorialUi;
    bool round = false;
    bool tutorialDone;
    [SerializeField] float gameTime = 45.2f;
    [SerializeField] float puaseTime = 15f;

    [Header("<color=red>적</color> 관련")]
    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnPoint;
    float enemySpawnTime = 1;
    int enemySpawnNumber;
    [SerializeField] int maxEnemySpawnNumber;
    int enemyCountNums;

    [Header("<color=blue>토큰</color> 관련")]
    [SerializeField] List<Button> listTokkenButton;
    [SerializeField] List<TMP_Text> listTokkenText;
    List<int> listTokken = new List<int>();

    [Header("튜토리얼 관련")]
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text enemyNumsText;

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
        round = false; 
        TokkenSetup();
    }

    private void TokkenSetup()
    {
        for (int i = 0; i < listTokkenButton.Count; i++)
        {
            listTokken.Add(0);
        }
    }

    void Update()
    {
        tutorialClicker();
        tokken();
        enemyCount();
        if (tutorialDone == true && round == true)
        {
            roundStart();
        }
        if(tutorialDone == true)
        {
            timer();
        }
        
    }

    private void enemyCount()
    {
        enemyNumsText.text = enemyCountNums.ToString();
    }

    private void timer()
    {
        if(round == true)
        {
            float gameTimer = gameTime;
            gameTimer -= Time.deltaTime;
            timerText.text = Mathf.FloorToInt(gameTimer).ToString();
            if(gameTime <= 0)
            {
                gameTimer = gameTime;
                round = false;
                
            }
        }
        else if (round == false)
        {
            float puaseTimer = puaseTime;
            puaseTimer -= Time.deltaTime;
            timerText.text = Mathf.FloorToInt(puaseTimer).ToString();
            if (puaseTimer <= 0)
            {
                puaseTimer = puaseTime;
                round = true;
            }
        }
    }



    private void tutorialClicker()
    {
        if (Input.GetMouseButtonDown(0) && timeNumsHas == true && goldMixHas == true)
        {
            timeNums.SetActive(false);
            goldMix.SetActive(false);
            black.SetActive(false);
            tutorialDone = true;
            round = true;
        }
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




    private void roundStart()
    {
        bool pick = false;
        if (round == false && pick == false)
        {
            for(int i = 0; i < 2; i++)
            {
                int index = Random.Range(0, 7);
                int a = listTokken[index];
                listTokken[index] = a + 1;
                Debug.Log($"{index}번째 토큰의 갯수 = {listTokken[index]}");
            }
        }
        pick = true;
        enemySpawnNumber = 0;
        spawnEnemy();
    }

    private void spawnEnemy()
    {
        if (enemySpawnNumber >= maxEnemySpawnNumber) return;
        enemySpawnTime -= Time.deltaTime;
        if(enemySpawnTime <= 0)
        {
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
            enemySpawnTime = 1;
            enemySpawnNumber++;
            enemyCountNums++;
        }
    }

    private void tokken()
    {
        for(int i = 0; i < listTokkenButton.Count; i++)
        {
            listTokkenText[i].text = listTokken[i].ToString();
        }
    }



}
