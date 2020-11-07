using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{

	public Text highScore;

	public void Start()
	{
		highScore.text = "HIGH SCORE : " + PlayerPrefs.GetInt("highScore");
	}

    public void Update()
    {
		if (Input.anyKeyDown)
			loadMain();
	}

    public void loadMain()
	{
		SceneManager.LoadScene("Main");
	}
}
