using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

	// Use this for initialization
	public static PlayerControllerScript instance {get; private set;}
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
	private UICharacterController myUICharControl;

	bool isRightDirection;
	bool canShoot;
	bool canShootCor;
	bool canMove;


	int addDmg;

	public bool IsRightDirection
	{
		get {return isRightDirection;}
	}

	public BuffReciever MyBuffReciever
	{
		get {return myBuffReciever;}
	}

	void Awake() 
	{
		instance = this;
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

		myBuffReciever = GetComponent<BuffReciever>();
		myBuffReciever.OnBuffChanges += OnHealthChange;
		myBuffReciever.OnBuffChanges += OnForceChange;
		myBuffReciever.OnBuffChanges += OnDamageChange;

		GameManager.inst.playerController = this;
		addDmg = 0;
	}

	public void InitButtonController(UICharacterController uiControl)
	{
		myUICharControl = uiControl;
		myUICharControl.UpButton.onClick.AddListener(Jump);
		myUICharControl.FireButton.onClick.AddListener(CheckForShootClick);
	}

	private void OnHealthChange()
	{
		for (int i = 0; i < myBuffReciever.Buffs.Count; ++i)
		{
			if ((myBuffReciever.Buffs[i].type == BuffType.Armor) && !myBuffReciever.Buffs[i].isUsed)
			{
				myBuffReciever.Buffs[i].isUsed = true;
				GameManager.inst.healthContainer[gameObject].AddHealth((int)myBuffReciever.Buffs[i].additiveBonus);
			}
		}
	}

	private void OnForceChange()
	{
		for (int i = 0; i < myBuffReciever.Buffs.Count; ++i)
		{
			if ((myBuffReciever.Buffs[i].type == BuffType.Force) && !myBuffReciever.Buffs[i].isUsed)
			{
				myBuffReciever.Buffs[i].isUsed = true;
				upForce += myBuffReciever.Buffs[i].additiveBonus;
			}
		}
	}

	private void OnDamageChange()
	{
		for (int i = 0; i < myBuffReciever.Buffs.Count; ++i)
		{
			if ((myBuffReciever.Buffs[i].type == BuffType.Damage) && !myBuffReciever.Buffs[i].isUsed)
			{
				myBuffReciever.Buffs[i].isUsed = true;
				addDmg = (int)myBuffReciever.Buffs[i].additiveBonus;
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Move();
		myAnimator.SetFloat("Speed", Mathf.Abs(directionMove.x));

		//CheckForShootClick();
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
#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
#endif

		/*
		if (Input.GetKeyDown(KeyCode.Space) && GDC.onGround)
		{
			isJumping = true;
			canShoot = false;
			myRigid.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
			myAnimator.SetTrigger("WasJump");
		}	
		*/
		//CheckForShootClick();
	}

	void Jump()
	{
		if (GDC.onGround)
		{
			isJumping = true;
			canShoot = false;
			myRigid.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
			myAnimator.SetTrigger("WasJump");
		}	
	}

	void Move()
	{
		directionMove = Vector3.zero;

#if UNITY_EDITOR
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
#endif


		if (myUICharControl.LeftButton.IsPressed)
		{
			directionMove = Vector3.left;
			isRightDirection = false;
			//transform.Translate(Vector2.left * sideVelosity * Time.fixedDeltaTime);
		}	

		if (myUICharControl.RightButton.IsPressed)
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
	}

	void CheckForShootClick()
	{
		if (canShoot && canShootCor)
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
			arrow.AddDamage(addDmg);
			arrow.SetImpulse(Vector2.right, mySprRenderer.flipX ? -1 : 1);
			StartCoroutine(RechargeCororutine());
		}
	}

	IEnumerator RechargeCororutine()
	{
		canShootCor = false;
		myUI.OpenReload(true);
		myUI.OpenReload2(true);
		for (int i = 0; i <= 10; ++i)
		{
			myUI.SetReloadPart(i / 10.0f);
			myUI.SetReloadPart2(i / 10.0f);
			yield return new WaitForSeconds(0.05f);
		}
		canShootCor = true;
		myUI.OpenReload(false);
		myUI.OpenReload2(false);
	}

}
