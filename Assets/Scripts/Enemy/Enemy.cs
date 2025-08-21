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
		Movement();
	}

	public virtual void Movement()
	{
		AnimatorStateInfo state = spriteAnimator.GetCurrentAnimatorStateInfo(0);
		if (target == pointA && !state.IsName("Idle"))
		{
			spriteRenderer.flipX = true;
		}
		else if (target == pointB && !state.IsName("Idle"))
		{
			spriteRenderer.flipX = false;

		}
		if (state.IsName("Idle") && spriteAnimator.GetBool("inCombat")) return;
		if (canMove) transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		if (Vector3.Distance(transform.position, target.position) < 0.1f)
		{
			if (target == pointA)
			{
				target = pointB;
				spriteAnimator.SetTrigger("idle");

			}
			else
			{
				spriteAnimator.SetTrigger("idle");
				target = pointA;
			}

			if (Vector3.Distance(transform.position, player.transform.position) > 2)
			{
				spriteAnimator.SetBool("inCombat", false);
			}

		}
	}

	public bool CanMove
	{
		get { return canMove; }
		set { canMove = value; }
	}

}
