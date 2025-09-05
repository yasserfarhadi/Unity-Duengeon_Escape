using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Shop : MonoBehaviour
{

	private int currentSelectedItem = 0;
	[SerializeField] GameObject _shopPanel;
	private Player _player;

	// void Awake()
	// {
	// 	_player = GameObject.Find("Player").GetComponent<Player>();
	// }
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && _shopPanel)
		{
			Player player = other.GetComponent<Player>();
			if (player)
			{
				UIManager.Instance.OpenShop(player.Diamonds);
				_player = player;
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



	public void SelectItem(int item)
	{
		currentSelectedItem = item;
		UIManager.Instance.UpdateShopSelection(item);
	}

	public void BuyItem()
	{
		int cost = 200;
		if (currentSelectedItem == 0) cost = 200;
		if (currentSelectedItem == 1) cost = 400;
		if (currentSelectedItem == 2) cost = 100;
		if (_player.Diamonds >= cost)
		{
			_player.Diamonds -= cost;
			UIManager.Instance.UpdateGemCount(_player.Diamonds);
			if (currentSelectedItem == 2) GameManager.Instance.HasKeyToCastle = true;
		}
		else
		{
			Debug.Log("Poor peace of shit!");
		}
		_shopPanel.SetActive(false);

	}
}
