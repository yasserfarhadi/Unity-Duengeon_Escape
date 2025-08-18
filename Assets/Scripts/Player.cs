using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

	[SerializeField] float jumpForce = 5f, _speed = 2.5f;
	public Transform groundCheck;
	private float groundDistance = 0.1f;
	[SerializeField] LayerMask groundLayer;
	private Rigidbody2D _rb;
	private PlayerAnimation _playerAnimation;
	private SpriteRenderer _spriteRenderer;
	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		_playerAnimation = GetComponent<PlayerAnimation>();
		_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}

	void Update()
	{
		Movement();
	}
	void Movement()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		Flip(moveX);
		Vector2 move = new Vector2(moveX * _speed, _rb.velocity.y);
		_rb.velocity = move;
		_playerAnimation.Move(moveX);
		bool _isGrounded = IsGrounded();

		if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
		{
			_rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
			_playerAnimation.JumpStart();
		}
		if (_isGrounded)
		{
			_playerAnimation.InAir(false);
		}
		else
		{
			_playerAnimation.InAir(true);
		}
	}
	bool IsGrounded()
	{
		bool isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundDistance, groundLayer);
		// Debug.DrawRay(groundCheck.position, Vector2.down * 0.1f, Color.green);
		return isGrounded;
	}
	void Flip(float move)
	{
		if (move < 0)
		{
			_spriteRenderer.flipX = true;
		}
		else if (move > 0)
		{
			_spriteRenderer.flipX = false;
		}
	}
}
