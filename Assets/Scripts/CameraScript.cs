using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Bimo;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - Bimo.transform.position;
    }

    void LateUpdate()
    {
        if (Bimo != null)
        {
            Vector3 targetPosition = Bimo.transform.position + offset;
            transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        }
    }
}
