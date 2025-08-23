using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Spider : Enemy, IDamagable
{
    public int Health { get; set; }
    [SerializeField] GameObject _acidPrefab;

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public void Damage(int damageAmount)
    {
        Health--;
        if (Health < 1)
        {
            // Destroy(gameObject);
            isDead = true;
            spriteAnimator.SetTrigger("death");
        }
    }
    public override void Update()
    {
        // base.Update();
    }
    public void Attack()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        bool isOnScreen = pos.x >= 0f && pos.x <= 1f &&
                  pos.y >= 0f && pos.y <= 1f;
        if (isOnScreen) Instantiate(_acidPrefab, transform.position, Quaternion.identity);
    }
}