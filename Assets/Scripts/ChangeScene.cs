using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject player, player2;
    public Canvas canvas;
    public GameObject prefabTutorial;
    GameObject menu;
    public bool chk = true;
    void Awake()
    {

    }

    void Start()
    {
        player.GetComponent<PlayerController>().enabled = false;
        player2.GetComponent<Animator>().enabled = false;
        Vector3 creatingpoint = canvas.transform.localPosition;
        menu = Instantiate(prefabTutorial, creatingpoint, Quaternion.identity) as GameObject;
        StartCoroutine(Destroyy());
        

    }
    IEnumerator Destroyy()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(menu);
        player.GetComponent<PlayerController>().enabled = true;
        player2.GetComponent<Animator>().enabled = true;
    }
    public void MainLoad()
    {
        SceneManager.LoadScene("Main");

    }

    public void TutorialLoadDelete()
    {
        if (chk)
        {
            chk = false;
            player.GetComponent<PlayerController>().enabled = false;
            player2.GetComponent<Animator>().enabled = false;
            Vector3 creatingpoint = canvas.transform.localPosition;
            menu = Instantiate(prefabTutorial, creatingpoint, Quaternion.identity) as GameObject;
        }
        else
        {
            chk = true;
            player.GetComponent<PlayerController>().enabled = true;
            player2.GetComponent<Animator>().enabled = true;
            Destroy(menu);
        }

    }

}