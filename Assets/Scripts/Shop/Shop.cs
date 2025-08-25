using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Shop : MonoBehaviour
{

	[SerializeField] GameObject _shopPanel;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && _shopPanel)
		{
			Player player = other.GetComponent<Player>();
			if (player)
			{
				UIManager.Instance.OpenShop(player.Diamonds);
			}
			_shopPanel.SetActive(true);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player" && _shopPanel)
		{
			_shopPanel.SetActive(false);
		}
	}

	public void SelectItem()
	{
		Debug.Log("asdawd");
	}
}
