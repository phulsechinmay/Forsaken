using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 150f;
	public Vector2 maxVelocity = new Vector2(60, 100);
	public float jetSpeed = 200f;
	public bool standing;
	public float standingThreshold = 4f;
	public float airSpeedMultiplier = 0.3f;

	private Rigidbody2D body2D;
	private SpriteRenderer spriteRenderer;
	private PlayerController controller;
	private Animator animator;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		body2D = GetComponent<Rigidbody2D>();
		controller = GetComponent<PlayerController>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		var absVelX = Mathf.Abs(body2D.velocity.x);
		var absVelY = Mathf.Abs(body2D.velocity.y);

		standing = (absVelY <= standingThreshold) ? true : false;

		var forceX = 0f;
		var forceY = 0f;

		if (controller.moving.x != 0)
		{
			if (absVelX < maxVelocity.x)
			{

				var newSpeed = speed * controller.moving.x;

				forceX = (standing) ? newSpeed : (newSpeed * airSpeedMultiplier);
               
                spriteRenderer.flipX = forceX < 0;
			}

			animator.SetInteger("AnimState", 1);
		}
		else {
			animator.SetInteger("AnimState", 0);
		}

		if(controller.moving.y > 0){
			if(absVelY < maxVelocity.y){
				forceY = jetSpeed * controller.moving.y;
			}
            
            
			animator.SetInteger("AnimState", 2);
		}
		else if(absVelY >= 0 && !standing){
			animator.SetInteger("AnimState", 3);
		}

		body2D.AddForce(new Vector2(forceX, forceY));
	}
}
