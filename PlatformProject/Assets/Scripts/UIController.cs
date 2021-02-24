using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text coinsVol;
	public Text healthVol;
	// Use this for initialization
	void Start () {
		//coinsVol.text = "COINS: 0";
		//healthVol.text = "HEALTH: 100";
	}
	
	public void SetCoins(int coins)
	{
		coinsVol.text = "COINS: " + coins.ToString();
	}

	public void SetHealth(int health)
	{
		healthVol.text = "HEALTH: " + health.ToString();
	}
}
