using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : BaseController
{

	Rigidbody2D rigidbody;
	Rigidbody2D target;

	SpriteRenderer sprite;
	Animator animator;

	float speed;

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

		speed = 2;
		return true;
	}

	void Update()
    {
        
    }

    private void FixedUpdate()
    {
		MoveTarget();

	}
    private void LateUpdate()
    {
		sprite.flipX = Managers.Object.Player.rigidbody.position.x > rigidbody.position.x;
	}

    void MoveTarget()
    {
		if (!Managers.Object.Player)
			return;
		
		var dir = (Managers.Object.Player.rigidbody.position - rigidbody.position).normalized;
		rigidbody.MovePosition(rigidbody.position + dir * speed * Time.fixedDeltaTime);
		rigidbody.velocity = Vector2.zero; //충돌 시 밀려남 없애기
	}


}
