using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	public GameObject leftBorder;
	public GameObject rightBorder;
	public float velocity;
	Rigidbody2D myRigidBody;

	bool isRightDirection;

	Vector2 rightVel;
	Vector2 leftVel;

	GroundDetectionController GDC;
	SpriteRenderer SPR;

	Animator myAnimator;

	bool moveStop;

    public bool IsRightDirection
    {
        get {return isRightDirection;}
    }

	void Start () 
	{
		myRigidBody = GetComponent<Rigidbody2D>();
		isRightDirection = true;	

		rightVel = Vector2.right * velocity;
		leftVel = Vector2.left * velocity;

		GDC = gameObject.GetComponent<GroundDetectionController>();
		SPR = gameObject.GetComponent<SpriteRenderer>();
		myAnimator = gameObject.GetComponent<Animator>();

		moveStop = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (!moveStop)
        {
            if (isRightDirection && GDC.onGround)
            {
                myRigidBody.velocity = rightVel;
                if (transform.position.x > rightBorder.transform.position.x)
                {
                    isRightDirection = !isRightDirection;
                    SPR.flipX = false;
                }
            }
            else if (!isRightDirection && GDC.onGround)
            {
                myRigidBody.velocity = leftVel;
                if (transform.position.x < leftBorder.transform.position.x)
                {
                    isRightDirection = !isRightDirection;
                    SPR.flipX = true;
                }
            }

            myAnimator.SetFloat("speed", Mathf.Abs(myRigidBody.velocity.x));
        }
    }

    public void SetMoveStop(bool val)
	{
		moveStop = val;
	}
}
