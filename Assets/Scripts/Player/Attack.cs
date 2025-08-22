using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Attack : MonoBehaviour
{
	private Animator _spriteAnimator;
	private Player _player;
	void Awake()
	{
		_spriteAnimator = GetComponentInParent<Animator>();
		_player = GetComponentInParent<Player>();
	}
	void Start()
	{
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!_player.CanHit) return;
		Debug.Log("Player can hit");
		_player.CanHit = false;
		IDamagable hit = other.GetComponent<IDamagable>();
		Debug.Log(other.name);
		if (hit != null) hit.Damage();
	}
}
