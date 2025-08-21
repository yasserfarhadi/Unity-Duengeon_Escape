using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour {

	private Enemy _enemy;
	void Awake()
	{
		_enemy = GetComponentInParent<Enemy>();
	}
	public void ResetCanMove()
	{
		_enemy.CanMove = true;
	}
}
