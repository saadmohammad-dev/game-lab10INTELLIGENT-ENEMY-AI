using UnityEngine;
using UnityEngine.AI;
 
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyPatrolChase : MonoBehaviour
{
    public Transform player;
    public Transform[] patrolPoints;
 
    [Header("Perception")]
    public float detectionRadius = 6f;
    public float loseRadius = 9f;
 
    [Header("Movement")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 3.5f;
    public float waypointTolerance = 0.35f;
    public float chaseStoppingDistance = 1.2f;
    public float repathInterval = 0.2f;
 
    private enum AIState { Patrol, Chase }
    private AIState state = AIState.Patrol;
    private NavMeshAgent agent;
    private Animator animator;
    private int waypointIndex;
    private float nextRepathTime;
 
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }
 
    private void Start()
    {
        if (player == null)
        {
            GameObject found = GameObject.FindGameObjectWithTag("Player");
            if (found != null) player = found.transform;
        }
 
        if (patrolPoints == null || patrolPoints.Length == 0)
        {
            Debug.LogError("Assign patrol points to EnemyPatrolChase.");
            enabled = false;
            return;
        }
 
        if (!agent.isOnNavMesh)
        {
            Debug.LogError("Enemy must start on a baked NavMesh.");
            enabled = false;
            return;
        }
 
        agent.speed = patrolSpeed;
        agent.stoppingDistance = 0.15f;
        GoToWaypoint();
    }
 
    private void Update()
    {
        if (!agent.isOnNavMesh) return;
 
        float distance = player == null ? Mathf.Infinity :
            Vector3.Distance(transform.position, player.position);
 
        if (state == AIState.Patrol && distance <= detectionRadius)
            BeginChase();
        else if (state == AIState.Chase && distance >= loseRadius)
            BeginPatrol();
 
        if (state == AIState.Patrol)
        {
            if (!agent.pathPending &&
                agent.remainingDistance <= agent.stoppingDistance + waypointTolerance)
            {
                waypointIndex = (waypointIndex + 1) % patrolPoints.Length;
                GoToWaypoint();
            }
        }
        else if (player != null && Time.time >= nextRepathTime)
        {
            nextRepathTime = Time.time + repathInterval;
            agent.SetDestination(player.position);
        }
 
        if (animator != null)
        {
            float normalizedSpeed = agent.velocity.magnitude /
                                    Mathf.Max(chaseSpeed, 0.1f);
            animator.SetFloat("Speed", normalizedSpeed, 0.1f, Time.deltaTime);
        }
    }
 
    private void BeginChase()
    {
        if (player == null) return;
        state = AIState.Chase;
        agent.speed = chaseSpeed;
        agent.stoppingDistance = chaseStoppingDistance;
        nextRepathTime = 0f;
        Debug.Log("Enemy state: CHASE");
    }
 
    private void BeginPatrol()
    {
        state = AIState.Patrol;
        agent.speed = patrolSpeed;
        agent.stoppingDistance = 0.15f;
        GoToWaypoint();
        Debug.Log("Enemy state: PATROL");
    }
 
    private void GoToWaypoint()
    {
        Transform point = patrolPoints[waypointIndex];
        if (agent.isOnNavMesh && point != null)
            agent.SetDestination(point.position);
    }
 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, loseRadius);
    }
}