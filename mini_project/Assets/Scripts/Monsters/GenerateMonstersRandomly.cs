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
    public float maxNumberOfMonsterToSpawned;
    private int monstersCount = 0;
    public float delayToSpawnAnotherMonster; //in seconds
    private float durationAfterStartedTheGame;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateRandomlyMonsters());
        durationAfterStartedTheGame = Time.time;
    }

    /// Update is called every frame, if the MonoBehaviour is enabled.
    void Update()
    {
        durationAfterStartedTheGame = Time.time;
        Debug.Log("middleMonster-tag is " + middleMonster.gameObject.tag);

        if (durationAfterStartedTheGame >= 0.20f) { //match 3 mins 1.80f
            Debug.Log("Duration is " + durationAfterStartedTheGame);
            if(middleMonster.gameObject.CompareTag("MiddleMonster")) {
                this.GenerateOtherMonsters(middleMonster, 3, 0.10f);
            } else {
                Debug.LogError("Tag MiddleMonster not found !");
            }
        }

        if (durationAfterStartedTheGame >= 0.30f) { //match 4 mins 2.40f
            Debug.Log("Duration is " + durationAfterStartedTheGame);
            if(strongMonster.gameObject.CompareTag("StrongMonster")) {
                this.GenerateOtherMonsters(middleMonster, 3, 0.10f);
            } else {
                Debug.LogError("Tag StrongMonster not found !");
            }
        }
    }

    IEnumerator GenerateRandomlyMonsters() {
        while (monstersCount < maxNumberOfMonsterToSpawned) {
            xPos = Random.Range(gameObject.transform.position.x - gameObject.transform.localScale.x / 2, 
                                gameObject.transform.position.x + gameObject.transform.localScale.x / 2);
            zPos = Random.Range(gameObject.transform.position.z - gameObject.transform.localScale.z / 2, 
                                gameObject.transform.position.z + gameObject.transform.localScale.z / 2);
            Instantiate(easyMonster, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(delayToSpawnAnotherMonster);
            monstersCount ++;
        }
    }

    void GenerateOtherMonsters(GameObject monster, int tempMonstersCount, float delay) {
        Debug.Log("Generate other monster: [" + monster.gameObject.tag + "]");
        while (monstersCount < maxNumberOfMonsterToSpawned) {
            xPos = Random.Range(gameObject.transform.position.x - gameObject.transform.localScale.x / 2, 
                                gameObject.transform.position.x + gameObject.transform.localScale.x / 2);
            zPos = Random.Range(gameObject.transform.position.z - gameObject.transform.localScale.z / 2, 
                                gameObject.transform.position.z + gameObject.transform.localScale.z / 2);
            Instantiate(monster, new Vector3(xPos, 0, zPos), Quaternion.identity);
            new WaitForSeconds(delay);
            tempMonstersCount ++;
        }
    }

}
