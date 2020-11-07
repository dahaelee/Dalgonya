using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anima;
    PlayerController playercont;
    GameController gamecont;

    // Start is called before the first frame update
    void Start()
    {
        anima = GameObject.Find("img").GetComponent<Animator>();
        playercont = GetComponent<PlayerController>();
        gamecont = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // jump
        {
            anima.SetInteger("Input", 1);
        }
        else if (Input.GetKeyUp(KeyCode.Space)) //run
        {
            anima.SetInteger("Input", 0);
        }

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (playercont.IsStun()) // 스턴상태인지 체크
            return;

        // 장애물 태그 별로 다르게 반응하기
        if (hit.gameObject.tag == "heartminus")
        {
            anima.SetInteger("Input", -1);
        }
        else if (hit.gameObject.tag == "reverse")
        {
            anima.SetInteger("Input", 2);
        }
        
        else anima.SetInteger("Input", 0);

        if (hit.gameObject.tag == "Sil")
        {
            gamecont.itemscore = 30;
        }

        else if (hit.gameObject.tag == "Mouse")
        {
            gamecont.itemscore = 50;
        }

        else if(hit.gameObject.tag == "Tuna")
        {
            gamecont.itemscore = 100;
        }

        Debug.Log(gamecont.itemscore);
    }
}
