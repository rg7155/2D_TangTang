using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : BaseController
{
	[SerializeField]
	float speed;

	public Rigidbody2D rigidbody
	{
		get;
		private set;
	}

	SpriteRenderer sprite;
	Animator animator;

	public Vector2 inputVector
	{
		get;
		private set;
	}

void Start()
	{
		Init();
	}

	protected override bool Init()
	{
		if (base.Init() == false)
			return false;

		rigidbody = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();


		return true;
	}

	void Update()
    {
        
    }
	void FixedUpdate()
    {
		var vec = inputVector * speed * Time.fixedDeltaTime;
		rigidbody.MovePosition(rigidbody.position + vec);
    }

	void LateUpdate()
	{
		animator.SetFloat("Speed", inputVector.magnitude);//∫§≈Õ ≈©±‚
		//animator.SetBool("Speed", );

		if (inputVector.x != 0) sprite.flipX = inputVector.x < 0;
	}


	void OnMove(InputValue value)
    {
		inputVector = value.Get<Vector2>();
	}
}
