using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGAnimations;
[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    public float attackCooldown = 0f;
    public float attackDelay;
    private CharacterStats characterStats;
    private CharacterAnimator animator;

    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        animator = GetComponent<CharacterAnimator>();
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public virtual void AttemptAttack(GameObject target){
        // check ranges attack cooldowns etc
        // perform attack if viable;
        if(attackCooldown <= 0 && TargetIsInRange(target.transform.position)){
            Attack(target);
        }
    }

    public void TakeDamage(int _damageAmount)
    {
        _damageAmount -= characterStats.armour.GetValue();
        _damageAmount = Mathf.Clamp(_damageAmount, 0, int.MaxValue);

        characterStats.currentHealth -= _damageAmount;
        print(gameObject + "took" + _damageAmount + "damage");

        if(characterStats.currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // die in some way
        //this is supposed to be overWritten
    }

    private void Attack(GameObject _target)
    {
        if (attackCooldown <= 0)
        {
            _target.SendMessage("TakeDamage", characterStats.damage.GetValue());
            attackCooldown = 1f / attackSpeed;
            animator.PlayAttackAnimation();
            print(gameObject.name + " Attacked "+ _target.name + " for damage: " +characterStats.damage.GetValue());
        }
    }

    private bool TargetIsInRange(Vector3 _targetPosition){
        float distance = Vector3.Distance(transform.position, _targetPosition);
        return (distance <= characterStats.attackRange.GetValue());
    }
}
