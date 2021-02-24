using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDamageController : MonoBehaviour
{
    public int damage;
	public string collisionTag;
    //EnemyController enemyMoveControl;
	PlayerControllerScript myMoveControl;

    GameObject enemy;

    bool coroutineStarts;
	float strikeInterval = 0.5f;
	float strikeTimer = 0.0f;

    public bool StopCoroutineStatus
    {
        set {coroutineStarts = value;}
        get {return coroutineStarts;}
    }
    // Start is called before the first frame update
    void Start()
    {
        coroutineStarts = false;
        myMoveControl = gameObject.GetComponent<PlayerControllerScript>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(collisionTag))
        {
            enemy = col.gameObject;
            //enemyMoveControl = enemy.GetComponent<EnemyController>();

            // Meet enemy by face
            if ((myMoveControl.IsRightDirection && gameObject.transform.position.x <= enemy.transform.position.x) ||
                (!myMoveControl.IsRightDirection && gameObject.transform.position.x > enemy.transform.position.x))
                {
                    col.gameObject.GetComponent<HealthController>().ReduceHealth(damage);
                    strikeTimer = 0.0f;
                    coroutineStarts = true;
                }

            // Meet enemy by back - do nothing and suffer
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(collisionTag))
        {
            coroutineStarts = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (coroutineStarts && enemy != null)
		{
			strikeTimer += Time.deltaTime;
			if (strikeTimer >= strikeInterval)
			{
				enemy.GetComponent<HealthController>().ReduceHealth(damage);
				strikeTimer = 0.0f;
			}
		}
    }

    public void StopAttack()
    {
        coroutineStarts = false;
        enemy = null;
    }
}
