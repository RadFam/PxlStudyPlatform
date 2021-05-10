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
		if (col.gameObject.CompareTag("Coin") && !GameManager.inst.coinContainer[col.gameObject].IsTaken)
		{
			GameManager.inst.coinContainer[col.gameObject].OnTake();
			//Debug.Log("Coin is taken " + col.gameObject.transform.parent.gameObject.name);
			myCoinsCount++;
			myUI.SetCoins(myCoinsCount);	
		}

		if (col.gameObject.CompareTag("AidKit") && !GameManager.inst.healthKitContainer[col.gameObject].IsTaken)
		{
			myHealth.AddHealth(GameManager.inst.healthKitContainer[col.gameObject].GetHealth());
		}

		if (col.gameObject.CompareTag("Portal"))
		{
			Destroy(col.gameObject);
			gameObject.GetComponent<PlayerControllerScript>().OnWinLevel();
		}
	}
}
