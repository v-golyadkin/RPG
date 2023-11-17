using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    Character character;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float defaultTimeToAttack = 2f;
    float attackTimer;

    Animator animator;
    CharacterMovement characterMovement;

    InteractableObject target;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        character = GetComponent<Character>();
    }

    private void Update()
    {
        AttackTimerTick();

        if(target != null)
        {
            ProcessAttack();
        }    
    }

    private void AttackTimerTick()
    {
        if(attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
        }
    }

    internal void Attack(InteractableObject target)
    {
        this.target = target;

        ProcessAttack();

    }

    private void ProcessAttack()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < attackRange)
        {
            if(attackTimer > 0f) { return; }

            attackTimer = GetAttackTime();

            characterMovement.Stop();
            animator.SetTrigger("Attack");

            Character targetCharacterToAttack = target.GetComponent<Character>();

            targetCharacterToAttack.TakeDamage(character.TakeStats(Statistic.Damage).integer_value);

            target = null;
        }
        else
        {
            characterMovement.SetDestination(target.transform.position);
        }
    }

    float GetAttackTime()
    {
        float attackTime = defaultTimeToAttack;

        attackTime /= character.TakeStats(Statistic.AttackSpeed).float_value;

        return attackTime;
    }
}
