using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Moss_Giant : Enemy
{
	// Use this for initialization
	void Start()
	{
		target = pointB;
	}

	// Update is called once per frame
	public override void Update()
	{
		AnimatorStateInfo state = _spriteAnimator.GetCurrentAnimatorStateInfo(0);
		if (target == pointA && !state.IsName("Idle"))
		{
			_spriteRenderer.flipX = true;
		}
		else if(target == pointB && !state.IsName("Idle"))
		{
			_spriteRenderer.flipX = false;
			
		}
		if (state.IsName("Idle")) return;
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
			if (target == pointA)
			{
				target = pointB;
				_spriteAnimator.SetTrigger("idle");
				// _spriteRenderer.flipX = false;

			}
			else
			{
				// _spriteRenderer.flipX = true;
				_spriteAnimator.SetTrigger("idle");
				target = pointA;
			}
				
			
        }
	}


}
