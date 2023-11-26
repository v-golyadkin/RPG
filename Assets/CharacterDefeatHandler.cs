using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class CharacterDefeatHandler : MonoBehaviour
{
    NavMeshAgent agent;
    AIEnemy aiEnemy;
    Collider objectCollider;

    AttackInput attackInput;
    InteractInput interactInput;
    PlayerCharacterInput playerCharacterInput;
    CharacterMovementInput characterMovementInput;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        aiEnemy = GetComponent<AIEnemy>();
        objectCollider = GetComponent<Collider>();

        attackInput = GetComponent<AttackInput>();
        interactInput = GetComponent<InteractInput>();
        playerCharacterInput = GetComponent<PlayerCharacterInput>();
        characterMovementInput = GetComponent<CharacterMovementInput>();
    }

    public void Defeated()
    {
        agent.isStopped = true;
        agent.enabled = false;

        objectCollider.enabled = false;

        if (aiEnemy != null)
        {
            aiEnemy.enabled = false;
        }



        if(attackInput != null)
        {
            attackInput.enabled = false;
        }

        if(interactInput != null)
        {
            interactInput.enabled = false;
        }

        if(playerCharacterInput != null)
        {
            playerCharacterInput.enabled = false;
        }

        if (characterMovementInput != null)
        {
            characterMovementInput.enabled = false;
        }
    }

    internal void Respawn()
    {
        agent.isStopped = false;
        agent.enabled = true;

        objectCollider.enabled = true;

        if (aiEnemy != null)
        {
            aiEnemy.enabled = true;
        }



        if (attackInput != null)
        {
            attackInput.enabled = true;
        }

        if (interactInput != null)
        {
            interactInput.enabled = true;
        }

        if (playerCharacterInput != null)
        {
            playerCharacterInput.enabled = true;
        }

        if (characterMovementInput != null)
        {
            characterMovementInput.enabled = true;
        }
    }
}
