using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Character character;
    [SerializeField] float default_MoveSpeed = 3.5f; 

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<Character>();
    }

    private void Start()
    {
        float moveSpeed = character.TakeStats(Statistic.MoveSpeed).float_value;    
        agent.speed = default_MoveSpeed * moveSpeed;
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
