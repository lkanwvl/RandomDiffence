using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainSceneManager : MonoBehaviour
{
    [SerializeField] List<Button> ListBtns;

    void Awake()
    {
        initButton();

        Tool.isEnterFirstScene = true;
    }

    void Update()
    {
        
    }

    private void initButton()
    {
        ListBtns[0].onClick.AddListener(onStart);
        ListBtns[1].onClick.AddListener(() => onExit());
    }

    private void onStart()
    {
        SceneManager.LoadSceneAsync("TutorialScene");
    }

    private void onExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
