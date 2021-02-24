using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetectionController : MonoBehaviour {

	// Use this for initialization
	public bool onGround;
	void Start () 
	{
		onGround = false;
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("Platform"))
		{
			onGround = true;
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("Platform"))
		{
			onGround = false;
		}
	}
}
