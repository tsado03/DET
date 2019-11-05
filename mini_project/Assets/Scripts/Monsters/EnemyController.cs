using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //NavMeshAgent steuern den Enemy über das NavMesh
    public NavMeshAgent agent;
    public GameObject target;
    private bool mostFollowPlayer = false;
    private int nbrOfBulletsToDieEasyM = 3;
    private int nbrOfBulletsToDieMiddleM = 12;
    private int nbrOfBulletsToDieStrongM = 8;
    private float waitBeforGoFollowTheNewTarget = 02.50f; //The monster will move to a random position
    private bool isInCorouting;
    private Vector3 positionToWalkTo;
    private NavMeshPath pathOfPositionToWalkTo;//object will not move if pah is invalid
    private bool isPathValid;

    // Start is called before the first frame update
    void Start()
    {
        pathOfPositionToWalkTo = new NavMeshPath();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.CompareTag("EasyMonster")) {
            target = GameObject.FindGameObjectWithTag("Player");
            // Sucht das target GameObject und bewegt sich zu ihm
            Vector3 vectorToTarget = target.transform.position;
            agent.SetDestination(vectorToTarget);
        } else if (agent.CompareTag("MiddleMonster")) {
            //The are moving to a random position(its update every time)
            if (!isInCorouting) {
                StartCoroutine(ManageDelaytimeToGetANewPosition());
            }
        } else if (agent.CompareTag("StrongMonster")) {
            if (agent.transform.position.Equals(new Vector3(0, 1, 0))) {
                mostFollowPlayer = true;
            }
            if (mostFollowPlayer == false) {
                agent.SetDestination(new Vector3(0, 0, 0));
            } else {
                Debug.Log("Monster most follow player's position, when reach the center!");
                target = GameObject.FindGameObjectWithTag("Player");
                Vector3 vectorToTarget = target.transform.position;
                agent.SetDestination(vectorToTarget);
            }
        }
    }

    void OnCollisionEnter(Collision bullet) {
        if (gameObject.tag.Equals("EasyMonster")) {
            if (bullet.gameObject.CompareTag("SimpleBoullet")) {
                nbrOfBulletsToDieEasyM--;
            }
            if (nbrOfBulletsToDieEasyM == 0) {
                Debug.Log("Monster most die if hitted with 4 bullets !");
                Destroy(gameObject);
            }
        }
        if (gameObject.tag.Equals("MiddleMonster")) {
            if (bullet.gameObject.CompareTag("SimpleBoullet")) {
                nbrOfBulletsToDieMiddleM--;
            }
            if (nbrOfBulletsToDieMiddleM == 0) {
                Debug.Log("Monster most die if hitted with 4 bullets !");
                Destroy(gameObject);
            }
        }
        if (gameObject.tag.Equals("StrongMonster")) {
            if (bullet.gameObject.CompareTag("SimpleBoullet")) {
                nbrOfBulletsToDieStrongM--;
            }
            if (nbrOfBulletsToDieStrongM == 0) {
                Debug.Log("Monster most die if hitted with 4 bullets !");
                Destroy(gameObject);
            }
        }
    }

    Vector3 GetNewRandomPosition() {
        return new Vector3(Random.Range(-20.00f, 20.00f), 0, Random.Range(-7.4f, 7.4f));
    }

    IEnumerator ManageDelaytimeToGetANewPosition() {
        isInCorouting = true;
        yield return new WaitForSeconds(waitBeforGoFollowTheNewTarget);
        MoveMonsterToNewPosition();
        isPathValid = agent.CalculatePath(positionToWalkTo, pathOfPositionToWalkTo);

        while (!isPathValid) {
            Debug.Log("Path is not valid, calculate a new one!");
            yield return new WaitForSeconds(0.02f);
            positionToWalkTo = GetNewRandomPosition();
            isPathValid = agent.CalculatePath(positionToWalkTo, pathOfPositionToWalkTo);
        }
        isInCorouting = false;
    }

    void MoveMonsterToNewPosition() {
        positionToWalkTo = GetNewRandomPosition();
        agent.SetDestination(positionToWalkTo);
    }
}
