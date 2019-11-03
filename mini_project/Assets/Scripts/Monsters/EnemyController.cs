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

    // Start is called before the first frame update
    void Start()
    {
        
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
            agent.SetDestination(new Vector3(Random.Range(-20.00f, 20.00f), 0, Random.Range(-7.4f, 7.4f)));
        } else if (agent.CompareTag("StrongMonster")) {
            if (agent.transform.position.Equals(new Vector3(0, 0.08332547f, 0))) {
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
}
