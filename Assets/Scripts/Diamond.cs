using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Diamond : MonoBehaviour
{
	private int _count = 1;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Player _player = other.GetComponent<Player>();
			if (_player)
			{
				_player.Diamonds += _count;
				Destroy(gameObject);
			}
		}
	}

	public int GemCount
	{
		get { return _count; }
		set { _count = value; }
	}
}
