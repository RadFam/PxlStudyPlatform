using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

	// Use this for initialization
	public float sideVelosity = 3.0f;
	public float upForce = 7.0f;

	public Rigidbody2D myRigid;
	public Transform arrowPos;

	GroundDetectionController GDC;

	private PoolShootObjects poolShoot;
	private Vector3 directionMove;
	private Animator myAnimator;
	private SpriteRenderer mySprRenderer;
	private bool isJumping;

	bool isRightDirection;
	bool canShoot;
	bool canMove;

	public bool IsRightDirection
	{
		get {return isRightDirection;}
	}

	void Start()
	{
		GDC = gameObject.transform.GetChild(1).gameObject.GetComponent<GroundDetectionController>();
		directionMove = Vector3.zero;
		myAnimator = gameObject.GetComponent<Animator>();
		mySprRenderer = gameObject.GetComponent<SpriteRenderer>();
		poolShoot = GameObject.Find("ArrowPool").GetComponent<PoolShootObjects>();

		isRightDirection = true;
		canShoot = false;
		canMove = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		directionMove = Vector3.zero;
		if (Input.GetKey(KeyCode.A))
		{
			directionMove = Vector3.left;
			isRightDirection = false;
			//transform.Translate(Vector2.left * sideVelosity * Time.fixedDeltaTime);
		}	

		if (Input.GetKey(KeyCode.D))
		{
			directionMove = Vector3.right;
			isRightDirection = true;
			//transform.Translate(Vector2.right * sideVelosity * Time.fixedDeltaTime);
		}

		directionMove *= sideVelosity;
		directionMove.y = myRigid.velocity.y;
		myRigid.velocity = directionMove;

		if (directionMove.x > 0)
		{
			mySprRenderer.flipX = false;
		}
		if (directionMove.x < 0)
		{
			mySprRenderer.flipX = true;
		}

		myAnimator.SetFloat("Speed", Mathf.Abs(directionMove.x));
	}

	void Update()
	{
		myAnimator.SetBool("IsGrounded", GDC.onGround);
		if(!isJumping && !GDC.onGround)
		{
			myAnimator.SetTrigger("WasFall");
		}
		isJumping = isJumping && !GDC.onGround;
		canShoot = !isJumping;

		if (Input.GetKeyDown(KeyCode.Space) && GDC.onGround)
		{
			isJumping = true;
			canShoot = !isJumping;
			myRigid.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
			myAnimator.SetTrigger("WasJump");
		}	

		CheckForShootClick();
	}

	void CheckForShootClick()
	{
		if (Input.GetMouseButtonDown(0) && canShoot)
		{
			Debug.Log("Input.GetMouseButtonDown(0) " + Input.GetMouseButtonDown(0) + "  canShoot " + canShoot);
			myAnimator.SetTrigger("IsArchering");
		}
	}

	void CheckForShoot()
	{
		ArrowControl arrow = poolShoot.listFreeArrows[0].GetComponent<ArrowControl>();
		arrow.gameObject.SetActive(true);
		arrow.transform.position = arrowPos.position;
		arrow.SetImpulse(Vector2.right, mySprRenderer.flipX ? -1 : 1);
	}

}
