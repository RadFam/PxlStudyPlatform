using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKitController : MonoBehaviour {

	// Use this for initialization
	public int restoreHealth;
	[SerializeField]
	Animator myAnim;
	bool isTaken;

	public bool IsTaken
	{
		get {return isTaken;}
	}

	void Start() 
    {
		isTaken = false;
        GameManager.inst.healthKitContainer.Add(gameObject, this);
    }

	public int GetHealth()
	{
		isTaken = true;
		myAnim.SetTrigger("AidKitTaken");
		return restoreHealth;
	}

	public void SelfDestroy(int a)
	{
		Destroy(this.gameObject);
	}
}
