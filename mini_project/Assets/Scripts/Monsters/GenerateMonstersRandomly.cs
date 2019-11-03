using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMonstersRandomly : MonoBehaviour
{
    public GameObject easyMonster;
    public GameObject middleMonster;
    public GameObject strongMonster;
    private float xPos;
    private float zPos;
    public float maxNumberOfMonsterToBeSpawned;
    private int monstersCount = 0;
    public float delayToSpawnAnotherMonster; //in seconds
    private float durationAfterStartedTheGame;
    private int maxMiddleMonsters = 2;
    private int maxStrongMonsters = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateRandomlyMonsters());
    }

    /// Update is called every frame, if the MonoBehaviour is enabled.
    void Update()
    {
        durationAfterStartedTheGame = Time.realtimeSinceStartup;

        if (durationAfterStartedTheGame >= 180.00f && durationAfterStartedTheGame <= 180.20f) { //match 3 mins
            Debug.Log("==> Time in seconds is: " + durationAfterStartedTheGame);
            if(middleMonster.gameObject.CompareTag("MiddleMonster") && maxMiddleMonsters > 0) {
                xPos = Random.Range(gameObject.transform.position.x - gameObject.transform.localScale.x / 2, 
                                    gameObject.transform.position.x + gameObject.transform.localScale.x / 2);
                zPos = Random.Range(gameObject.transform.position.z - gameObject.transform.localScale.z / 2, 
                                    gameObject.transform.position.z + gameObject.transform.localScale.z / 2);
                Instantiate(middleMonster, new Vector3(xPos, 0, zPos), Quaternion.identity);
            } else {
                Debug.Log("Maximum of monster is reached!");
            }
            maxMiddleMonsters--;
        }

        if (durationAfterStartedTheGame >= 240.00f && durationAfterStartedTheGame <= 240.20f) { //match 4 mins
            Debug.Log("==> Time in seconds is: " + durationAfterStartedTheGame);
            if(strongMonster.gameObject.CompareTag("StrongMonster")  && maxStrongMonsters > 0) {
                xPos = Random.Range(gameObject.transform.position.x - gameObject.transform.localScale.x / 2, 
                                    gameObject.transform.position.x + gameObject.transform.localScale.x / 2);
                zPos = Random.Range(gameObject.transform.position.z - gameObject.transform.localScale.z / 2, 
                                    gameObject.transform.position.z + gameObject.transform.localScale.z / 2);
                Instantiate(strongMonster, new Vector3(xPos, 0, zPos), Quaternion.identity);
            } else {
                Debug.LogError("Maximum of monster is reached!");
            }
            maxStrongMonsters--;
        }
    }

    IEnumerator GenerateRandomlyMonsters() {
        while (monstersCount < maxNumberOfMonsterToBeSpawned) {
            xPos = Random.Range(gameObject.transform.position.x - gameObject.transform.localScale.x / 2, 
                                gameObject.transform.position.x + gameObject.transform.localScale.x / 2);
            zPos = Random.Range(gameObject.transform.position.z - gameObject.transform.localScale.z / 2, 
                                gameObject.transform.position.z + gameObject.transform.localScale.z / 2);
            Instantiate(easyMonster, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(delayToSpawnAnotherMonster);
            monstersCount ++;
        }
    }

}
