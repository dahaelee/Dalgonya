using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenningMove : MonoBehaviour
{
    public GameObject camera;
    Animator animator;
    Animator cameraAnim;

    void Start()
    {
        animator = GetComponent<Animator>();
        cameraAnim = camera.GetComponent<Animator>();
        cameraAnim.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            cameraAnim.enabled = true;
            //SceneManager.LoadScene("Title");
        }

        if (cameraAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
