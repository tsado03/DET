using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //NavMeshAgent steuern den Enemy über das NavMesh
    public NavMeshAgent agent;
    public GameObject target;

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
            if (agent.gameObject.transform.position.Equals(new Vector3(0, 0, 0))) {
                agent.SetDestination(new Vector3(Random.Range(-20.00f, 20.00f), 0, Random.Range(-7.4f, 7.4f)));
            } else {
                //the are moving to the center
                agent.SetDestination(new Vector3(0, 0, 0));
            }
        }
    }
}
