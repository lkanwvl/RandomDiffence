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
    [SerializeField] float gameTime = 45f;
    [SerializeField] float puaseTime = 15f;
    [SerializeField] TMP_Text goldText;
    int getGold;
    bool pick = false;

    [Header("<color=red>적</color> 관련")]
    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnPoint;
    float enemySpawnTime = 1;
    int enemySpawnNumber;
    [SerializeField] int maxEnemySpawnNumber;
    int enemyCountNums;
    [SerializeField] int gameOverNums;

    [Header("<color=blue>토큰</color> 관련")]
    [SerializeField] List<Button> listTokkenButton;
    [SerializeField] List<TMP_Text> listTokkenText;
    List<int> listTokken = new List<int>();
    [SerializeField] List<Transform> listTokkenLocation;
    int tokkenLocation = 0;

    [Header("튜토리얼 관련")]
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text enemyNumsText;
    public int roundCount = 0;

    [Header("<color=yellow>타워</color> 관련")]
    [SerializeField] List<GameObject> listTower; 

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

    private void Start()
    {
        //Transform trsSlotManager = GameObject.Find("UiObjact/SlotManager").transform;
        //int count = trsSlotManager.childCount;
        //for (int iNum = 0; iNum < count; ++iNum)
        //{
        //    listTokkenLocation2.Add(trsSlotManager.GetChild(iNum));
        //}
        tokkenButton();
    }

    private void tokkenButton()
    {
        int count = listTokkenButton.Count;
        for (int iNum = 0; iNum < count; iNum++)
        {
            int tokkenNum = iNum;
            listTokkenButton[iNum].onClick.AddListener(() => spawnTokken(tokkenNum));
        }
    }

    private void spawnTokken(int _value)
    {
        if (listTokken[_value] > 0)
        {
            int slotNum = checkEmptySlot();
            if (slotNum != -1)
            {
                Instantiate(listTower[_value], listTokkenLocation[slotNum]);
                listTokken[_value] -= 1;
            }
        }
    }

    private int checkEmptySlot()
    {
        int count = listTokkenLocation.Count;
        for (int i = 0; i < count; i++)
        {
            Transform trsList = listTokkenLocation[i];
            if (trsList.childCount == 1)
            {
                return i;
            }
        }
        return -1;
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
        goldText.text = getGold.ToString();
        if(enemyCountNums >= gameOverNums)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }

    private void enemyCount()
    {
        enemyNumsText.text = enemyCountNums.ToString();
    }

    public void KillEnemy()
    {
        enemyCountNums -= 1;
    }

    private void timer()
    {
        if (round == true)
        {
            gameTime -= Time.deltaTime;
            timerText.text = $"{Mathf.FloorToInt(gameTime)} / {roundCount}";
            if (gameTime <= 0)
            {
                round = false;
                gameTime = 45;
            }
        }
        else if (round == false)
        {
            puaseTime -= Time.deltaTime;
            timerText.text = $"{Mathf.FloorToInt(puaseTime)} / {roundCount}";
            if (puaseTime <= 0)
            {
                round = true;
                pick = false;
                puaseTime = 15;
                roundCount++;
            }


        }
    }

    public void Kill()
    {
        getGold += 2;
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
        round = false;
        if (round == false && pick == false)
        {
            for(int i = 0; i < 2; i++)
            {
                int index = Random.Range(0, 8);
                int a = listTokken[index];
                listTokken[index] = a + 1;
            }
        }
        pick = true;
        round = true;
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
