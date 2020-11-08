using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{
    public Text score;
    public Text highScore;

    void Start()
    {
        score.text = GameController.score.ToString();
        highScore.text = "HIGHSCORE : " + GameController.highscore.ToString();

    }

    void Update()
    {
        
    }
}
