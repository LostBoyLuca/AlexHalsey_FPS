using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 10f;
    public float attackRange = 2f;
    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;
    
    private NavMeshAgent agent;
    private Animator animator;
    private bool isChasing = false;
    private bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Patrol();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            AttackPlayer();
        }
        else if (distance <= chaseRange)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0 || isChasing) return;

        animator.SetBool("IsChasing", false);
        animator.SetBool("IsAttacking", false);
        agent.speed = 2f;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    void ChasePlayer()
    {
        isChasing = true;
        animator.SetBool("IsChasing", true);
        animator.SetBool("IsAttacking", false);
        agent.speed = 5f;
        agent.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        isChasing = false;
        isAttacking = true;
        animator.SetBool("IsAttacking", true);
        animator.SetBool("IsChasing", false);
        agent.SetDestination(transform.position); // Stop moving
        // TODO: Add attack logic (e.g., damage player)
    }
}

