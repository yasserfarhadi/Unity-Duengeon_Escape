using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Skeleton : Enemy, IDamagable
{
    public int Health { get; set; }


    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Movement()
    {
        base.Movement();
        if (player.IsPlayerDead()) return;
        AnimatorStateInfo state = spriteAnimator.GetCurrentAnimatorStateInfo(0);
        bool isInAttack = state.IsName("Attack");
        bool isInHit = state.IsName("Hit");
        bool isAggro = spriteAnimator.GetBool("aggro");
        Vector3 direction = player.transform.localPosition - transform.localPosition;

        isFacingPlayer = IsFacingPlayer(direction);
        if (isAggro) Chase(direction);
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > 2) spriteAnimator.SetBool("aggro", false);
        if (distance <= 1 && !isInAttack && !isInHit && isFacingPlayer)
        {
            spriteAnimator.SetBool("aggro", true);
        }
        if (distance <= 0.6 && !isInAttack && !isInHit && isAggro)
        {
            spriteAnimator.SetTrigger("attack");
        }
    }

    void Chase(Vector3 direction)
    {
        if (direction.x < 0)
        {
            if (target != pointA) target = pointA;
        }
        else if (direction.x > 0)
        {
            if (target != pointB) target = pointB;
        }
    }

    bool IsFacingPlayer(Vector3 direction)
    {
        if (direction.x < 0)
        {
            if (target == pointA) return true;
            return false;
        }
        else if (direction.x > 0)
        {
            if (target == pointB) return true;
            return false;
        }
        return false;
    }


    public void Damage(int damageAmount)
    {
        if (isDead) return;
        Health--;
        spriteAnimator.SetTrigger("hit");
        spriteAnimator.SetBool("aggro", true);
        CanMove = false;
        if (Health < 1)
        {
            // Destroy(gameObject);
            spriteAnimator.SetTrigger("death");
            isDead = true;
            InstanciateDiamonds();
        }
    }
}
