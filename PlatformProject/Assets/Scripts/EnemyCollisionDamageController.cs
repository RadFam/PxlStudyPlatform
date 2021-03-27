using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDamageController : MonoBehaviour {

	public int damage;
	public string collisionTag;
	Animator myAnimator;

	Vector3 myMoveDirection;
	Vector3 opposeMoveDirection;

	float moveDirectionScalarProd = 0.0f;

	bool coroutineStarts;
	float biteInterval = 0.5f;
	float biteTimer = 0.0f;

	GameObject player;

	EnemyController myMoveControl;
	PlayerControllerScript playerControllerScript;

	void Awake()
	{
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerScript>();
		myMoveControl = gameObject.GetComponent<EnemyController>();
		myAnimator = gameObject.GetComponent<Animator>();
		coroutineStarts = false;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag(collisionTag))
		{
			//Debug.Log("OnCollisionEnter2D" + "  name: " + gameObject.name);
			player = col.gameObject;
			// Case 1 - enemy is behind player, enemy strikes back
			if ((!myMoveControl.IsRightDirection && !playerControllerScript.IsRightDirection && gameObject.transform.position.x >= col.gameObject.transform.position.x) || 
				(myMoveControl.IsRightDirection &&  playerControllerScript.IsRightDirection && gameObject.transform.position.x <= col.gameObject.transform.position.x))
				{
					col.gameObject.GetComponent<HealthController>().ReduceHealth(damage);
					//Debug.Log("Case 1, damage: " + damage.ToString());
					SetMoveStatus(true);
					myAnimator.SetTrigger("startAttack"); // HERE WE SET TRIGGER TO ATTACK (with inner pause)
				}
			
			// Case 2 - enemy is in front of player, player strikes back
			if ((!myMoveControl.IsRightDirection && !playerControllerScript.IsRightDirection && gameObject.transform.position.x < col.gameObject.transform.position.x) || 
				(myMoveControl.IsRightDirection && playerControllerScript.IsRightDirection && gameObject.transform.position.x > col.gameObject.transform.position.x))
				{
					// Rotate face to player
					gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
					//Debug.Log("Case 2, damage: " + damage.ToString());
					SetMoveStatus(true);
					myAnimator.SetTrigger("startAttack"); // HERE WE SET TRIGGER TO ATTACK (with inner pause)	
				}
			// Case 3 - enemy and player meets face-to-face
			if ((!myMoveControl.IsRightDirection && playerControllerScript.IsRightDirection && gameObject.transform.position.x >= col.gameObject.transform.position.x) || 
				(myMoveControl.IsRightDirection && !playerControllerScript.IsRightDirection && gameObject.transform.position.x < col.gameObject.transform.position.x))
				{
					col.gameObject.GetComponent<HealthController>().ReduceHealth(damage);
					//Debug.Log("Case 3, damage: " + damage.ToString());
					SetMoveStatus(true);
					myAnimator.SetTrigger("startAttack"); // HERE WE SET TRIGGER TO ATTACK (with inner pause)
				}
			// Case 4 - enemy and player meets back-to-back
			if ((myMoveControl.IsRightDirection && !playerControllerScript.IsRightDirection && gameObject.transform.position.x >= col.gameObject.transform.position.x) || 
				(!myMoveControl.IsRightDirection && playerControllerScript.IsRightDirection && gameObject.transform.position.x < col.gameObject.transform.position.x))
				{
					// Rotate face to player
					gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
					//Debug.Log("Case 4, damage: " + damage.ToString());
					SetMoveStatus(true);
					myAnimator.SetTrigger("startAttack"); // HERE WE SET TRIGGER TO ATTACK (with inner pause)
				}
		}
	}

/*
	void OnCollisionExit2D(Collision2D col)
	{
        if (col.gameObject.CompareTag(collisionTag) && coroutineStarts)
        {
            Debug.Log("OnCollisionExit2D");
            myAnimator.SetTrigger("stopAttack"); // HERE WE TRIGGER TO STOP ATTACK

            //gameObject.GetComponent<SpriteRenderer>().flipX = myMoveControl.IsRightDirection;
            myMoveControl.SetMoveStop(false);
        }
	}
*/
	/*
	void Update()
	{
		if (coroutineStarts)
		{
			biteTimer += Time.deltaTime;
			if (biteTimer >= biteInterval)
			{
				player.GetComponent<HealthController>().ReduceHealth(damage);
				Debug.Log("Case 5, damage: " + damage.ToString());
				//coroutineStarts = false;
				biteTimer = 0.0f;
			}
		}
	}
	*/

	public void AttackPlayer()
	{
		player.GetComponent<HealthController>().ReduceHealth(damage);
		//Debug.Log("Case 6, damage: " + damage.ToString());
	}

	public void SetMoveStatus(bool val)
	{
		if (!val)
		{
			gameObject.GetComponent<SpriteRenderer>().flipX = myMoveControl.IsRightDirection;
		}
		myMoveControl.SetMoveStop(val);
	}

	public void SetMoveStatusInt(int val)
	{
		//Debug.Log("SetMoveStatusInt was invoked");
		if (val == 0)
		{
			SetMoveStatus(false);
		}
		else
		{
			SetMoveStatus(true);
		}
	}

}
