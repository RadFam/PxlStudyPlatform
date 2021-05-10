using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject upPosition;
	public GameObject downPosition;

    public float velocity;
	Rigidbody2D myRigidBody;
    bool isUpDirection;
    Vector2 upVel;
	Vector2 downVel;
    void Start()
    {
        isUpDirection = true;
        myRigidBody = GetComponent<Rigidbody2D>();

        upVel = Vector2.up * velocity;
        downVel = Vector2.down * velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (isUpDirection)
        {
            myRigidBody.velocity = upVel;
            if (transform.position.y >= upPosition.transform.position.y)
            {
                isUpDirection = !isUpDirection;
            }
        }
        else
        {
            myRigidBody.velocity = downVel;
            if (transform.position.y <= downPosition.transform.position.y)
            {
                isUpDirection = !isUpDirection;
            }
        }
    }
}
