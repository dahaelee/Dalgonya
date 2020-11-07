using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zdiff;
    public GameObject target;
    public float followSpeed;

    void Start()
    {
        zdiff = target.transform.position.z - transform.position.z;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,
                                         transform.position.y,
                                         Mathf.Lerp(transform.position.z, target.transform.position.z-zdiff, Time.deltaTime * followSpeed));
    }
}
