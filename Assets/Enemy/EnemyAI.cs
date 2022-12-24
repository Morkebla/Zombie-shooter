using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform targetedPlayer;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float attackCooldown = 2f;
    [SerializeField] float turnSpeed = 5f;

 
    NavMeshAgent navMeshAgent;
    float distanceToTargetedPlayer = Mathf.Infinity;
    bool isProvoked = false;
    float attack = 0f;
    private Vector3 playerCoordinates => targetedPlayer.transform.position;
    EnemyHealth health;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        distanceToTargetedPlayer = Vector3.Distance(targetedPlayer.position, transform.position);
        if (isProvoked)
        {
            
            EngageTarget();

        } 
        else if (distanceToTargetedPlayer < chaseRange)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTargetedPlayer >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTargetedPlayer <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);  // easy to remember as DrawWireSphere ( on who, what?)  on who? is the AI, and what? AI's chaseRange. draw (AI's, ChaseRange)
    }
    void ChaseTarget()
    {
        if (!health.IsDead())
        {
            GetComponent<Animator>().SetBool("Attack", false);
            GetComponent<Animator>().SetTrigger("Move");
            navMeshAgent.SetDestination(playerCoordinates);
        }
    }
    void AttackTarget()
    {
        
        attack += Time.deltaTime;
        GetComponent<Animator>().SetBool("Attack", true);
        if (attack >= attackCooldown)
        {
            attack = 0f;
        }
        
    }
    private void FaceTarget()
    {
        Vector3 direction = (targetedPlayer.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0 , direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
