using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffectsController : MonoBehaviour {

	public GameObject minusPrefab;
	public GameObject minusEnemyPrefab;
	public GameObject plusPrefab;

	// Use this for initialization
	public void MakePlus(Vector3 pos)
	{
		//Debug.Log("Instantiate PLUS");
		Instantiate(plusPrefab, pos, Quaternion.identity);
	}

	public void MakeMinus(Vector3 pos)
	{
		Instantiate(minusPrefab, pos, Quaternion.identity);
	}

	public void MakeEnemyMinus(Vector3 pos)
	{
		Instantiate(minusEnemyPrefab, pos, Quaternion.identity);
	}
}
