using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] List<Button> listBtns;
    [SerializeField] List<Button> listBtnsNor;
    [SerializeField] List<Button> listBtnsLeg;
    [SerializeField] List<Button> listBtnsBoss;
    [SerializeField] List<Button> listBtnsTable;
    [SerializeField] List<GameObject> listGameobjact;
    
    

    private void Awake()
    {
        int count = listGameobjact.Count;
        for(int i = 0; i < count; i++)
        {
            goActive(listGameobjact[i], false);
        }
        initButten();
        initInsideBtnNor();
        initInsideBtnLeg();
        initInsideBtnBoss();
        initInsideBtnTable();
    }

    void initInsideBtnNor()
    {
        listBtnsNor[6].onClick.AddListener(() => { goActive(listGameobjact[0], false);});
        listBtnsNor[6].onClick.AddListener(() => { listBtns[0].interactable = true;});
        listBtnsNor[6].onClick.AddListener(() => { listBtns[1].interactable = true;});
        listBtnsNor[6].onClick.AddListener(() => { listBtns[2].interactable = true;});
        listBtnsNor[6].onClick.AddListener(() => { listBtns[3].interactable = true;});
    }
    void initInsideBtnLeg()
    {
        listBtnsLeg[6].onClick.AddListener(() => { goActive(listGameobjact[1], false);});
        listBtnsLeg[6].onClick.AddListener(() => { listBtns[0].interactable = true;});
        listBtnsLeg[6].onClick.AddListener(() => { listBtns[1].interactable = true;});
        listBtnsLeg[6].onClick.AddListener(() => { listBtns[2].interactable = true;});
        listBtnsLeg[6].onClick.AddListener(() => { listBtns[3].interactable = true;});
    }
    void initInsideBtnBoss()
    {
        listBtnsBoss[6].onClick.AddListener(() => { goActive(listGameobjact[2], false);}); 
        listBtnsBoss[6].onClick.AddListener(() => { listBtns[0].interactable = true; });
        listBtnsBoss[6].onClick.AddListener(() => { listBtns[1].interactable = true; });
        listBtnsBoss[6].onClick.AddListener(() => { listBtns[2].interactable = true; });
        listBtnsBoss[6].onClick.AddListener(() => { listBtns[3].interactable = true; });
    }
    void initInsideBtnTable()
    {
        listBtnsTable[6].onClick.AddListener(() => { goActive(listGameobjact[3], false);});
        listBtnsTable[6].onClick.AddListener(() => { listBtns[0].interactable = true; });
        listBtnsTable[6].onClick.AddListener(() => { listBtns[1].interactable = true; });
        listBtnsTable[6].onClick.AddListener(() => { listBtns[2].interactable = true; });
        listBtnsTable[6].onClick.AddListener(() => { listBtns[3].interactable = true; });
    }

    void initButten()
    {
        listBtns[0].onClick.AddListener(() => {goActive(listGameobjact[0], true);});
        listBtns[1].onClick.AddListener(() => {goActive(listGameobjact[1], true);});
        listBtns[2].onClick.AddListener(() => {goActive(listGameobjact[2], true);});
        listBtns[3].onClick.AddListener(() => {goActive(listGameobjact[3], true);});
    }

    private void goActive(GameObject go, bool _value)
    {
        if(_value == true)
        {
            go.SetActive(true);
        }
        else
        {
            go.SetActive(false);
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        int count = listGameobjact.Count;
        for (int i = 0; i < count; i++)
        {
            if (listGameobjact[i].activeSelf == true)
            {
                listBtns[0].interactable = false;
                listBtns[1].interactable = false;
                listBtns[2].interactable = false;
                listBtns[3].interactable = false;
            }
        }
    }
}
