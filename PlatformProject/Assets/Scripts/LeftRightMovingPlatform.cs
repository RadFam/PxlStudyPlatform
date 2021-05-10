using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMovingPlatform : MonoBehaviour
{
    public GameObject leftPosition;
	public GameObject rightPosition;

    public float velocity;
	Rigidbody2D myRigidBody;
    bool isRightDirection;
    Vector2 leftVel;
	Vector2 rightVel;
    void Start()
    {
        isRightDirection = true;
        myRigidBody = GetComponent<Rigidbody2D>();

        leftVel = Vector2.left * velocity;
        rightVel = Vector2.right * velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRightDirection)
        {
            myRigidBody.velocity = rightVel;
            if (transform.position.x >= rightPosition.transform.position.x)
            {
                isRightDirection = !isRightDirection;
            }
        }
        else
        {
            myRigidBody.velocity = leftVel;
            if (transform.position.x <= leftPosition.transform.position.x)
            {
                isRightDirection = !isRightDirection;
            }
        }
    }
}
