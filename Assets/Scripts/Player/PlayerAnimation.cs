using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

	private Animator _animator;
	private Animator _swordArcAnimator;
	void Start()
	{
		_animator = GetComponentInChildren<Animator>();
		_swordArcAnimator = GameObject.Find("Sword_Arc").GetComponent<Animator>();
	}
	public void Move(float val)
	{
		_animator.SetFloat("move", Mathf.Abs(val));
	}

	public void InAir(bool isJumping)
	{
		_animator.SetBool("jumping", isJumping);
	}
	public void JumpStart()
	{
		AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(0);
		if (state.IsName("Idle") || state.IsName("Run"))
		{
			_animator.SetTrigger("jumpstart");
		}
	}
	public void Attack()
	{
		AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(0);
		if (!state.IsName("Attack"))
		{
			_animator.SetTrigger("attack");
			_swordArcAnimator.SetTrigger("arc");
		}
	}
}

