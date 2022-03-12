using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSpeedDetect : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity);
    }
}
