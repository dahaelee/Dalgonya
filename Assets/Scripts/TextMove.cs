using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMove : MonoBehaviour
{
    public GameObject[] text = new GameObject [2];
    public float time;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
