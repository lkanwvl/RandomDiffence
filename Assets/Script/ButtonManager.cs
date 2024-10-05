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
        initButten();
        initInsideBtnNor();
        initInsideBtnLeg();
        initInsideBtnBoss();
        initInsideBtnTable();
    }

    void initInsideBtnNor()
    {
        listBtnsNor[6].onClick.AddListener(() => { goActive(listGameobjact[0], false);});
    }
    void initInsideBtnLeg()
    {
        listBtnsNor[6].onClick.AddListener(() => { goActive(listGameobjact[1], false);});
    }
    void initInsideBtnBoss()
    {
        listBtnsNor[6].onClick.AddListener(() => { goActive(listGameobjact[2], false);});
    }
    void initInsideBtnTable()
    {
        listBtnsNor[6].onClick.AddListener(() => { goActive(listGameobjact[3], false);});
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
        
    }
}
