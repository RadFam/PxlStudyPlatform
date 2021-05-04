using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text coinsVol;
	public Text healthVol;
	public Image healthBar;
	public GameObject reloadPanel;
	public Image reloadArea;
	public Image reloadArea2;
	public GameMenuScript gameMenuScript;
	public InventoryUIController inventory;

	bool invOpen;
	float currHealth;
	float nextHealth;
	float delta = 0.01f;

	// Use this for initialization
	void Start () {
		//coinsVol.text = "COINS: 0";
		//healthVol.text = "HEALTH: 100";
		gameMenuScript.gameObject.SetActive(false);
		invOpen = false;
		currHealth = 1.0f;
		nextHealth = 1.0f;
	}

	void Update()
	{
		if (nextHealth > currHealth)
		{
			currHealth += delta;
		}
		if (nextHealth < currHealth)
		{
			currHealth -= delta;
		}
		if (Mathf.Abs(currHealth - nextHealth) < delta)
		{
			currHealth = nextHealth;
		}

		healthBar.fillAmount = currHealth;
	}
	
	public void SetCoins(int coins)
	{
		coinsVol.text = "COINS: " + coins.ToString();
	}

	public void SetHealth(int health)
	{
		//healthVol.text = "HEALTH: " + health.ToString();
		nextHealth = health / 100.0f;
		//healthBar.fillAmount = newVal;
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

	public void OpenReload2(bool vol)
	{
		if (!vol)
		{
			reloadArea2.fillAmount = 0.0f;
		}
		if (vol)
		{
			reloadArea2.fillAmount = 0.0f;
		}
		reloadArea2.gameObject.SetActive(vol);
	}

	public void SetReloadPart(float vol)
	{
		reloadArea.fillAmount = vol;
	}

	public void SetReloadPart2(float vol)
	{
		reloadArea2.fillAmount = vol;
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
