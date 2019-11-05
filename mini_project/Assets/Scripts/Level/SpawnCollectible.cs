using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectible : MonoBehaviour
{
    public float timeUntilNextSpawn = 30.0f;
    public GameObject collectible;

    private Vector3[] spawnLocations;
    private float lastTimeSpawned;
    private GameObject lastInstantiated;

    void Start()
    {
        spawnLocations = new Vector3[3];
        spawnLocations[0] = new Vector3(-10, 1, 0); // Kreuzung direkt vorm linken Teleporter
        spawnLocations[1] = new Vector3(10, 1, 0);  // Kreuzung direkt vorm rechten Teleporter
        spawnLocations[2] = new Vector3(0, 1, -12); // Zwischen den unteren beiden "T"-Blöcken die übereinander stehen
        lastTimeSpawned = 0;
        lastInstantiated = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        /* Spawnt nach der angebenen Zeit ein neues (oder das erste) collectible Object (zb. Medpack).
         * Zerstört aber zuerst noch das alte so dass immer nur ein collectible von diesem Typen exisitert */
        if( Time.time - lastTimeSpawned >= timeUntilNextSpawn)
        {
            Destroy(lastInstantiated);
            int location = Random.Range(0, 3);
            lastInstantiated = Instantiate(collectible, spawnLocations[location], collectible.transform.rotation);
            lastInstantiated.name = collectible.name;
            lastTimeSpawned = Time.time;
        }
    }

    /* Testmethode die sofort ein Object spawned.
    void Spawn()
    {
        Destroy(lastInstantiated);
        int location = Random.Range(0, 3);
        lastInstantiated = Instantiate(collectible, spawnLocations[2], collectible.transform.rotation);
        lastTimeSpawned = Time.time;
        Debug.Log("Spawned Medpack");
    }
    //*/
}
