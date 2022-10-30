using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    
    [SerializeField] Transform target;
    public static float chaseRange = 5;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();   
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        MoveEnemy(distanceToTarget);
    }
    void MoveEnemy(float distanceToTarget)
    {
        if (distanceToTarget <= chaseRange)
        {
            navMeshAgent.SetDestination(target.position);

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 1, 0.5F);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
