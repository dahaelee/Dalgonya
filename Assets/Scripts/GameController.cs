using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	public PlayerController player;
	public Text scoreLabel;
	public LifePanel lifePanel;

	public void Update()
	{
		// 점수 업데이트 
		int score = CalcScore();
		scoreLabel.text = "SCORE " + score;

		// 생명 업데이트
		lifePanel.UpdateLife(player.Life());

		// 생명 개수 0 되면 게임 종료
		if (player.Life() <= 0)
		{
			// 더이상 업데이트 안함
			enabled = false;

			// 하이스코어 업데이트
			if (PlayerPrefs.GetInt("HighScore") < score)
			{
				PlayerPrefs.SetInt("HighScore", score);
			}

			// 타이틀 씬으로 돌아가기
			Invoke("loadTitle", 2.0f);
		}
	}

	int CalcScore()
	{
		// 점수 : 이동한 거리 (나중에 아이템점수 추가하기)
		return (int)player.transform.position.z * 1000;
	}

	void loadTitle()
	{
		SceneManager.LoadScene("Title");
	}
}
