using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocalPoint : MonoBehaviour
{
    public GameObject target;

    void LateUpdate()
    {
        transform.position = target.transform.position + new Vector3 (0 , 25 , 0);
    }
}
