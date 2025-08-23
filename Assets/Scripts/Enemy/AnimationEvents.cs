using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AnimationEvents : MonoBehaviour
{

	private Spider _sipder;

	void Awake()
	{
		_sipder = GetComponentInParent<Spider>();
	}
	public void ResetCanMove()
	{
		_sipder.CanMove = true;
	}

	public void FireAcid()
	{
		_sipder.Attack();
	}

}
