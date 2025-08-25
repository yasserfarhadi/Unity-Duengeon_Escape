using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	private static UIManager _instance;
	public static UIManager Instance
	{
		get
		{
			if (_instance == null) Debug.LogError("UI Manager is NULL");
			return _instance;
		}
	}

	[SerializeField] Text _gemText;
	[SerializeField] Image _selectionImg;
	// private Player _player;

	public void OpenShop(int gemCount)
	{
		_gemText.text = gemCount + " Gem" + (gemCount == 1 ? "" : "s");
	}

	private void Awake()
	{
		_instance = this;
		// _player = GameObject.Find("Player").GetComponent<Player>();
	}
}
