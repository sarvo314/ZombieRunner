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
    bool isProvoked = false;

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
        if(isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }
    void EngageTarget()
    {
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if(distanceToTarget < navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }
    void AttackTarget()
    {

    }
    void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 1, 0.5F);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
