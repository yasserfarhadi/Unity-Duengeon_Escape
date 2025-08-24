using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AnimationEvents : MonoBehaviour
{

	private Spider _sipder;
	private Moss_Giant _moss;
	private Skeleton _skeleton;

	void Awake()
	{
		_sipder = GetComponentInParent<Spider>();
		_moss = GetComponentInParent<Moss_Giant>();
		_skeleton = GetComponentInParent<Skeleton>();

	}
	public void SpiderResetMovement()
	{
		_sipder.CanMove = true;
	}
	public void MossResetMovement()
	{
		_moss.CanMove = true;
	}
	public void SkeletonResetMovement()
	{
		_skeleton.CanMove = true;
	}

	public void FireAcid()
	{
		_sipder.Attack();
	}

}
