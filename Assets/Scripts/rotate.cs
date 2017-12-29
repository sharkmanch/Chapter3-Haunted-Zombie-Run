using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] private float rotateRSpd = 200.0f;
    [SerializeField] private float rotateUSpd = 0.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.PlayerActive)
        {
            transform.RotateAround(transform.position, Vector3.up, rotateRSpd * Time.deltaTime);
            transform.RotateAround(transform.position, Vector3.left, rotateUSpd * Time.deltaTime);
        }
    }
}
