using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemsController : MonoBehaviour {

	// Use this for initialization
	UIController myUI;
	int myCoinsCount;
	HealthController myHealth;

	void Start()
	{
		myUI = FindObjectOfType<UIController>();
		myHealth = GetComponent<HealthController>();
		myCoinsCount = 0;
		myUI.SetCoins(myCoinsCount);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		//Debug.Log(col.gameObject.tag);
		if (col.gameObject.CompareTag("Coin"))
		{
			Debug.Log("Coin is taken");
			myCoinsCount++;
			myUI.SetCoins(myCoinsCount);
			GameManager.inst.coinContainer[col.gameObject].OnTake();
		}

		if (col.gameObject.CompareTag("AidKit"))
		{
			myHealth.AddHealth(GameManager.inst.healthKitContainer[col.gameObject].GetHealth());
		}
	}
}
