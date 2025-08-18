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
	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		Movement();
	}
	void Movement()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		Vector2 move = new Vector2(moveX * _speed, _rb.velocity.y);
		_rb.velocity = move;
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
		{
			_rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
		}
	}
	bool IsGrounded()
	{
		bool isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundDistance, groundLayer);
		// Debug.DrawRay(groundCheck.position, Vector2.down * 0.1f, Color.green);
		return isGrounded;
	}
}
