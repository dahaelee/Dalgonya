using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextMove : MonoBehaviour
{
    public GameObject camera;
    Animator cameraAnim;
    public GameObject[] text = new GameObject [2];
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        cameraAnim = camera.GetComponent<Animator>();
        cameraAnim.enabled = false;

        text[0].SetActive(true);
        text[1].SetActive(false);
        StartCoroutine(WaitMinute());
    }

    IEnumerator WaitMinute()
    {
        yield return new WaitForSeconds(time);
        text[1].SetActive(true);
        text[0].SetActive(false);
        StartCoroutine(WaitMinute2());
    }

    IEnumerator WaitMinute2()
    {
        yield return new WaitForSeconds(time);
        text[1].SetActive(false);
        text[0].SetActive(false);
        cameraAnim.enabled = true;
        StartCoroutine(WaitTitle());
    }

    IEnumerator WaitTitle()
    {
        yield return new WaitForSeconds(time-0.8f);
        SceneManager.LoadScene("Title");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
