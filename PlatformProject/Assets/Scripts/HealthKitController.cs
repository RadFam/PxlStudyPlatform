using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKitController : MonoBehaviour {

	// Use this for initialization
	public int restoreHealth;
	[SerializeField]
	Animator myAnim;
	void Start() 
    {
        GameManager.inst.healthKitContainer.Add(gameObject, this);
    }

	public int GetHealth()
	{
		myAnim.SetTrigger("AidKitTaken");
		return restoreHealth;
	}

	public void SelfDestroy(int a)
	{
		Destroy(this.gameObject);
	}
}
