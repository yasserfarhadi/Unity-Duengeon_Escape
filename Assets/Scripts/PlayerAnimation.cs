using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

	private Animator _animator;
	private Player _playerScript;

	void Start()
	{
		_animator = GetComponentInChildren<Animator>();
		_playerScript = GetComponent<Player>();
	}
	void Update()
	{
		AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(0);
    if (state.IsName("Idle") || state.IsName("Run"))
    {
        _playerScript.CanMove = true;
    }
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
		_playerScript.CanMove = false;
		_animator.SetTrigger("attack");
		}
	}
}

