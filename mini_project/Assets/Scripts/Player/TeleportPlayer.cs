﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    
    public GameObject player;
    public Transform teleportLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("gameObject ist the player");
            player.transform.position = teleportLocation.transform.position;
        } else {
            Debug.Log("Player is not the collider !");
        }
    }
}
