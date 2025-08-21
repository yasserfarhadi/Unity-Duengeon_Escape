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
    public void Daamge(int damageAmount)
    {
        Health--;
        spriteAnimator.SetTrigger("hit");
        spriteAnimator.SetBool("inCombat", true);
        CanMove = false;
        if (Health < 1)
        {
            Destroy(gameObject);
        }
    }
}
