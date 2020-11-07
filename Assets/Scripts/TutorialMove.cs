using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialMove : MonoBehaviour
{
    GameObject player, player2, canvas;
    public GameObject prefabTutorial;
    GameObject menu;

    void Awake()
    {
        player = GameObject.Find("cat");
        player2 = GameObject.Find("img");
        canvas = GameObject.Find("Canvas");
    }

    void Start()
    {

    }

    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void TutorialLoad()
    {

    }

}