﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBoulletBehavior : MonoBehaviour
{
    public float boulletSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * boulletSpeed);
    }

    void OnCollisionEnter(Collision col) {
        boulletSpeed = 0.0f;
        Destroy(gameObject);
    }
}
