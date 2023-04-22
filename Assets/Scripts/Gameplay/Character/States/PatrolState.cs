using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : IState<Character>
{
    public float wanderRadius = 25;
    public float wanderTimer = 5;

    private NavMeshAgent agent;
    private float timer;

    public void OnEnter(Character t)
    {
        agent = t.GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    public void OnExecute(Character t)
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(t.transform.position, wanderRadius, NavMesh.AllAreas);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public void OnExit(Character t)
    {

    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
    

}
