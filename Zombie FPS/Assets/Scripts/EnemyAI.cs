using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] float chaseRange = 5f;

    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(Target.position , transform.position);
        
        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget<=chaseRange)
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
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            FaceTarget();
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack",false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(Target.position);
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack",true);
    }

    void  FaceTarget()
    {
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x , 0 , direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation , LookRotation , Time.deltaTime*turnSpeed);

    }
    public void OnDamageTaken()
    {
        isProvoked = true;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f , 0f , 0f,0.7f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
