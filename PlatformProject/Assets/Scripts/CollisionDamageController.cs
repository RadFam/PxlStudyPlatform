using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageController : MonoBehaviour {

	// Use this for initialization
	public int damage;
	public string collisionTag;

	public float forceDamageCollision;

	Rigidbody2D myRigid;

	Animator myAnimator;

	void Start()
	{
		myRigid = GetComponent<Rigidbody2D>();
		myAnimator = gameObject.GetComponent<Animator>();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag(collisionTag))
		{
			// Check, if we behind OR in front of the player OR face-to-face to player OR tail-to-tail
			col.gameObject.GetComponent<HealthController>().ReduceHealth(damage);
			//Vector2 velocity = col.gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
			//col.gameObject.GetComponent<Rigidbody2D>().AddForce(velocity * forceDamageCollision, ForceMode2D.Impulse);
		}
	}

	void OnCollisionStay2D(Collision2D col)
	{

	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.CompareTag(collisionTag))
		{

		}
	}
}
