using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject powerUp;

    private float spawnDelay = 45.0f;
    private float lastTimeSpawned;
    private Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = new Vector3(0, 0, 0);
        lastTimeSpawned = Time.time;
    }

    private void Update()
    {
        // Spawnt sobald das spawnDelay überschritten ist ein neues Powerup zum einsammeln
        if (Time.time - lastTimeSpawned >= spawnDelay)
        {
            GameObject spawned = Instantiate(powerUp, spawnPoint, powerUp.transform.rotation);
            spawned.name = powerUp.name;
            lastTimeSpawned = Time.time;
        }
    }
}
