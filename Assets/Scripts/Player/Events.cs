using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{

	// Use this for initialization
	private Player _playerScript;
	void Start()
	{
		_playerScript = GetComponentInParent<Player>();
	}

	public void OnAttackStarts()
	{
		_playerScript.CanMove = false;
	}
	public void OnAttackEnd()
	{
		_playerScript.CanMove = true;
	}

	public void ResetHit()
	{
		_playerScript.CanHit = true;
		
	}
}
