using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] private float rotateSpd = 200.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.PlayerActive)
        {
            transform.Rotate(Vector3.right * rotateSpd * Time.deltaTime);
        }
    }
}
