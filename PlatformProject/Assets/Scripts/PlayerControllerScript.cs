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
	UIController myUI;
	private PoolShootObjects poolShoot;
	private Vector3 directionMove;
	private Animator myAnimator;
	private SpriteRenderer mySprRenderer;
	private bool isJumping;

	private BuffReciever myBuffReciever;

	bool isRightDirection;
	bool canShoot;
	bool canShootCor;
	bool canMove;

	public bool IsRightDirection
	{
		get {return isRightDirection;}
	}

	void Start()
	{
		myUI = FindObjectOfType<UIController>();
		GDC = gameObject.transform.GetChild(1).gameObject.GetComponent<GroundDetectionController>();
		directionMove = Vector3.zero;
		myAnimator = gameObject.GetComponent<Animator>();
		mySprRenderer = gameObject.GetComponent<SpriteRenderer>();
		poolShoot = GameObject.Find("ArrowPool").GetComponent<PoolShootObjects>();

		isRightDirection = true;
		canShoot = false;
		canShootCor = true;
		canMove = false;

		//myBuffReciever.OnBuffChanges += OnHealthChange;
		//myBuffReciever.OnBuffChanges += OnForceChange;
		//myBuffReciever.OnBuffChanges += OnDamageChange;
	}

	private void OnHealthChange()
	{

	}

	private void OnForceChange()
	{

	}

	private void OnDamageChange()
	{

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

		CheckForShootClick();
	}

	void Update()
	{
		myAnimator.SetBool("IsGrounded", GDC.onGround);
		if(!isJumping && !GDC.onGround)
		{
			myAnimator.SetTrigger("WasFall");
		}
		isJumping = isJumping && !GDC.onGround;
		canShoot = GDC.onGround; 

		if (Input.GetKeyDown(KeyCode.Space) && GDC.onGround)
		{
			isJumping = true;
			canShoot = false;
			myRigid.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
			myAnimator.SetTrigger("WasJump");
		}	

		//CheckForShootClick();
	}

	void CheckForShootClick()
	{
		if (Input.GetMouseButtonDown(0) && canShoot && canShootCor)
		{
			myAnimator.SetTrigger("IsArchering");
		}
	}

	void CheckForShoot()
	{
		if (poolShoot.listFreeArrows.Count > 0 && canShootCor)
		{
			ArrowControl arrow = poolShoot.listFreeArrows[0].GetComponent<ArrowControl>();
			arrow.gameObject.SetActive(true);
			arrow.transform.position = arrowPos.position;
			arrow.SetImpulse(Vector2.right, mySprRenderer.flipX ? -1 : 1);
			StartCoroutine(RechargeCororutine());
		}
	}

	IEnumerator RechargeCororutine()
	{
		canShootCor = false;
		myUI.OpenReload(true);
		for (int i = 0; i <= 10; ++i)
		{
			myUI.SetReloadPart(i / 10.0f);
			yield return new WaitForSeconds(0.05f);
		}
		canShootCor = true;
		myUI.OpenReload(false);
	}

}
