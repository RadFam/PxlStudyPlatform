using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text coinsVol;
	public Text healthVol;
	public GameObject reloadPanel;
	public Image reloadArea;
	public GameMenuScript gameMenuScript;
	public InventoryUIController inventory;

	bool invOpen;

	// Use this for initialization
	void Start () {
		//coinsVol.text = "COINS: 0";
		//healthVol.text = "HEALTH: 100";
		gameMenuScript.gameObject.SetActive(false);
		invOpen = false;
	}
	
	public void SetCoins(int coins)
	{
		coinsVol.text = "COINS: " + coins.ToString();
	}

	public void SetHealth(int health)
	{
		healthVol.text = "HEALTH: " + health.ToString();
	}

	public void OpenReload(bool vol)
	{
		if (!vol)
		{
			reloadArea.fillAmount = 0.0f;
		}
		reloadPanel.SetActive(vol);
		if (vol)
		{
			reloadArea.fillAmount = 0.0f;
		}
	}

	public void SetReloadPart(float vol)
	{
		reloadArea.fillAmount = vol;
	}

	public void OnMenuButtonClicked()
	{
		Time.timeScale = 0;
		gameMenuScript.gameObject.SetActive(true);
	}

	public void OpenInventory()
	{
		invOpen = !invOpen;
		inventory.gameObject.SetActive(invOpen);
	}
}
