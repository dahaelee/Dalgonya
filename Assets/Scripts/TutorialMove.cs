using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialMove : MonoBehaviour
{
    public int crtcnt = 0;
    public GameObject[] image = new GameObject[3];
    void Start()
    {
        image[0].SetActive(true);
        for (int i = 1; i < 3; i++)
        {
            image[i].SetActive(false);
        }
    }

    public void RightClick()
    {
        ++crtcnt;
        if (crtcnt >= 3) crtcnt = 0;
        for (int i=0;i<3;i++)
        {
            if (i == crtcnt)
            {
                image[i].SetActive(true);
            }
            else image[i].SetActive(false);
        }
    }

    public void LeftClick()
    {
        --crtcnt;
        if (crtcnt < 0) crtcnt = 2;
        for (int i = 0; i < 3; i++)
        {
            if (i == crtcnt)
            {
                image[i].SetActive(true);
            }
            else image[i].SetActive(false);
        }
    }

}