using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	[SerializeField] protected int gems, health;
	[SerializeField] protected float speed;
	[SerializeField] protected Transform pointA, pointB;
	protected Transform target;
	protected SpriteRenderer spriteRenderer;
	protected Animator spriteAnimator;
	protected Player player;
	protected bool canMove = true;
	protected bool isFacingPlayer = false;
	protected bool isDead = false;
	[SerializeField] protected GameObject _gemPrefab;

	public virtual void Init()
	{
		spriteRenderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();
		spriteAnimator = this.gameObject.GetComponentInChildren<Animator>();
		player = GameObject.Find("Player").GetComponent<Player>();
		target = pointB;
	}

	public virtual void Awake()
	{
		Init();
	}
	public virtual void Update()
	{
		if (!isDead) Movement();
	}

	void FlipCheck(AnimatorStateInfo state)
	{
		if (target == pointA && !state.IsName("Idle"))
		{
			spriteRenderer.flipX = true;
		}
		else if (target == pointB && !state.IsName("Idle"))
		{
			spriteRenderer.flipX = false;

		}
	}

	public virtual void Movement()
	{
		AnimatorStateInfo state = spriteAnimator.GetCurrentAnimatorStateInfo(0);
		FlipCheck(state);
		bool inAttack = state.IsName("Attack");

		if (state.IsName("Idle")) return;
		if (canMove && !inAttack) transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		if (Vector3.Distance(transform.position, target.position) < 0.1f)
		{
			if (target == pointA) target = pointB;
			else target = pointA;
			if (!inAttack) spriteAnimator.SetTrigger("idle");
		}

	}

	public bool CanMove
	{
		get { return canMove; }
		set { canMove = value; }
	}

	public void InstanciateDiamonds()
	{
		GameObject newDiamond = Instantiate(_gemPrefab, transform.position, Quaternion.identity);
		Diamond _diamond = newDiamond.GetComponent<Diamond>();
		_diamond.GemCount = gems;
	}

}
