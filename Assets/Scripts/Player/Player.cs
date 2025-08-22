using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour, IDamagable
{

	[SerializeField] float jumpForce = 5f, _speed = 2.5f;
	public Transform groundCheck;
	private float groundDistance = 0.1f;
	[SerializeField] LayerMask groundLayer;
	private Rigidbody2D _rb;
	private PlayerAnimation _playerAnimation;
	private SpriteRenderer _spriteRenderer;
	private GameObject _swordArc;
	private bool _canMove = true;
	private bool _canHit = true;
	private Vector3 _arcPos, _arcRot, _arcScale, _hitboxOffset;
	public int Health { get; set; }
	void Start()
	{
		Health = 5;
		_rb = GetComponent<Rigidbody2D>();
		_playerAnimation = GetComponent<PlayerAnimation>();
		_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		_swordArc = GameObject.Find("Sword_Arc");
		_arcPos = _swordArc.transform.localPosition;
		_arcRot = _swordArc.transform.localEulerAngles;
		_arcScale = _swordArc.transform.localScale;
	}

	void Update()
	{
		Movement();
		Attack();
	}

	void Attack()
	{
		if (Input.GetMouseButtonDown(0) && IsGrounded()) _playerAnimation.Attack();
	}
	void Movement()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		Flip(moveX);
		FlipArc(moveX);
		Vector2 move = new Vector2((_canMove ? moveX : 0) * _speed, _rb.velocity.y);
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
	void FlipArc(float move)
	{
		if (move < 0)
		{
			Vector3 mirroredPos = _arcPos;
			mirroredPos.x *= -1;

			Vector3 mirroredRot = _arcRot;
			mirroredRot.y *= -1;
			mirroredRot.z *= -1;

			Vector3 mirrorScale = _arcScale;
			mirrorScale.x *= -1;

			_swordArc.transform.localPosition = mirroredPos;
			_swordArc.transform.localEulerAngles = mirroredRot;
			_swordArc.transform.localScale = mirrorScale;
		}
		else if (move > 0)
		{
			_swordArc.transform.localPosition = _arcPos;
			_swordArc.transform.localEulerAngles = _arcRot;
			_swordArc.transform.localScale = _arcScale;
		}
	}

	public bool CanMove
	{
		get { return _canMove; }
		set { _canMove = value; }
	}
	public bool CanHit
	{
		get { return _canHit; }
		set { _canHit = value; }
	}
	public void Damage(int damageAmount)
	{
		Health--;
		// spriteAnimator.SetTrigger("hit");
		// spriteAnimator.SetBool("aggro", true);
		// CanMove = false;
		if (Health < 1)
		{
			Destroy(gameObject);
		}
	}
}
