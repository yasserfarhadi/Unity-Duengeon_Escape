using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // private Animator _spriteAnimator;
    // private Player _player;
    // void Awake()
    // {
    // 	_spriteAnimator = GetComponentInParent<Animator>();
    // 	_player = GetComponentInParent<Player>();
    // }
    // void Start()
    // {
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (!_player.CanHit) return;
        // _player.CanHit = false;
        Debug.Log("Name: " + other.name);
        IDamagable hit = other.GetComponent<IDamagable>();
        if (hit != null) hit.Damage();
    }
}
