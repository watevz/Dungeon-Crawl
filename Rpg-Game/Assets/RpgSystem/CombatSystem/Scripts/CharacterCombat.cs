using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGAnimations;
[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    float attackCooldown = 0f;
    public float attackDelay;

    public event System.Action OnAttack;
    CharacterStats characterStats;
    CharacterAnimator animator;

    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        animator = GetComponent<CharacterAnimator>();
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            if (OnAttack != null)
            {
                OnAttack();
            }
            attackCooldown = 1f / attackSpeed;
            animator.PlayAttackAnimation();
            print(gameObject.name + "Attacked"+ targetStats.gameObject.name);
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(characterStats.damage.GetValue());
    }
}
