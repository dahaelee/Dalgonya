﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    GameObject player, player2, canvas;
    public GameObject prefabTutorial;
    GameObject menu;
    public bool chk = true;

    void Awake()
    {
        player = GameObject.Find("cat");
        player2 = GameObject.Find("img");
        canvas = GameObject.Find("Canvas");
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            MainLoad();
        if (Input.GetKeyDown(KeyCode.BackQuote))
            TutorialLoad();
    }

    public void OpenningLoad()
    {
        SceneManager.LoadScene("Opennig");
    }

    public void TitleLoad()
    {
        SceneManager.LoadScene("Title");
    }

    public void MainLoad()
    {
        SceneManager.LoadScene("Main");
    }

    public void TutorialLoad()
    {
        if (chk)
        {
            chk = false;
            player.GetComponent<PlayerController>().enabled = false;
            player2.GetComponent<Animator>().enabled = false;
            GameObject.Find("HelpButton").GetComponent<Button>().enabled = false;
            Vector3 creatingpoint = canvas.transform.localPosition;
            menu = Instantiate(prefabTutorial, creatingpoint, Quaternion.identity) as GameObject;
        }
       
       

    }
    public void TutorialDelete()
    {
        chk = true;
        player.GetComponent<PlayerController>().enabled = true;
        player2.GetComponent<Animator>().enabled = true;
        GameObject.Find("HelpButton").GetComponent<Button>().enabled = true;
        Destroy(gameObject);
    }

}