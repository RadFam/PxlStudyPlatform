﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

	public int maxHealth;
	public int currHealth;

	UIController myUI;
	VisualEffectsController myVEC;

	// Use this for initialization
	void Start () 
	{
		currHealth = maxHealth;
		myUI = FindObjectOfType<UIController>();
		myVEC = FindObjectOfType<VisualEffectsController>();
		GameManager.inst.healthContainer.Add(gameObject, this);
	}
	
	public void AddHealth(int addHealth)
	{
		currHealth += addHealth;
		if (currHealth > maxHealth)
		{
			currHealth = maxHealth;
		}
        if (gameObject.CompareTag("Player"))
        {
            myUI.SetHealth(currHealth);
			myVEC.MakePlus(transform.position);
        }
	}

	public void ReduceHealth(int redHealth)
	{
		currHealth -= redHealth;

		if (currHealth < 0)
		{
			currHealth = 0;
		}
        if (gameObject.CompareTag("Player"))
        {
			GetComponent<Animator>().SetTrigger("IsWounded");
            myUI.SetHealth(currHealth);
			myVEC.MakeMinus(transform.position);
        }
		if (gameObject.CompareTag("Enemy"))
        {
			myVEC.MakeEnemyMinus(transform.position);
			EnemyUIController eUIC = gameObject.GetComponent<EnemyUIController>();
			eUIC.SetHealthRes(currHealth, maxHealth);
        }
		if (currHealth == 0)
		{
			if (gameObject.CompareTag("Player"))
			{
				Destroy(gameObject);
			}
			if (gameObject.CompareTag("Enemy"))
			{
				Debug.Log("Enemy dies");
				GameObject go = GameObject.Find("Player");
				Destroy(gameObject.transform.parent.gameObject);
			}
		}
	}
}
