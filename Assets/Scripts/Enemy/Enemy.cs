using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	[SerializeField] protected int gems, health, speed;
	[SerializeField] protected Transform pointA, pointB;
	protected Transform target;
	protected SpriteRenderer _spriteRenderer;
	protected Animator _spriteAnimator;

	void Awake()
	{
		_spriteRenderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();
		_spriteAnimator = this.gameObject.GetComponentInChildren<Animator>();
	}


	public abstract void Update();
}
