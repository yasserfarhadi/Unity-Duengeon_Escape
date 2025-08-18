using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

	private Animator _animator;

	void Start()
	{
		_animator = GetComponentInChildren<Animator>();
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
}

