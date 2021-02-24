using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEffectScript : MonoBehaviour {

	// Use this for initialization

	public float timeToLive;
	public float currTime;
	public float upSpeed;
	Color myColor;
	SpriteRenderer mySprite;
	void Start () {
		currTime = 0.0f;
		mySprite = GetComponent<SpriteRenderer>();
		myColor = mySprite.color;
	}
	
	// Update is called once per frame
	void Update () 
	{
		currTime += Time.deltaTime;
		transform.Translate(Vector2.up * upSpeed * Time.deltaTime);

		myColor = mySprite.color;
		float a = myColor.a;
		a -= Time.deltaTime * (timeToLive / 255.0f);
		myColor = new Color(myColor.r, myColor.g, myColor.b, a);
		mySprite.color = myColor;

		transform.localScale = new Vector3(transform.localScale.x * 1.01f, transform.localScale.y * 1.01f, transform.localScale.z);

		if (currTime >= timeToLive)
		{
			Destroy(gameObject);
		}
	}
}
