using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    int a = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 1.8f)
        {
            a = 1;
        }
        else  a = -1;
        transform.Translate(Vector3.up * 0.5f * Time.deltaTime * a);

        Debug.Log(transform.position.y);
    }

    IEnumerator UpMove()
    {
        yield return new WaitForSeconds(1.0f);
    }

}
