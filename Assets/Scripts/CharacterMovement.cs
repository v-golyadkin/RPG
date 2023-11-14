using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetDestination(Vector3 destinationPosition)
    {
        agent.isStopped = false;
        agent.SetDestination(destinationPosition);
    }

    internal void Stop()
    {
        agent.isStopped = true;
    }
}
