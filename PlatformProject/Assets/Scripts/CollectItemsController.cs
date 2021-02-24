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
			myCoinsCount++;
			myUI.SetCoins(myCoinsCount);
			Destroy(col.gameObject);
		}

		if (col.gameObject.CompareTag("AidKit"))
		{
			myHealth.AddHealth(col.gameObject.GetComponent<HealthKitController>().GetHealth());
			Destroy(col.gameObject);
		}
	}
}
