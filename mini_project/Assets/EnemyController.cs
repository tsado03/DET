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
        // Sucht das target GameObject und bewegt sich zu ihm
        Vector3 vecotToTarget = target.transform.position;
        agent.SetDestination(vecotToTarget);
    }
}
