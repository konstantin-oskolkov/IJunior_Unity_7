using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
   [SerializeField] private float _moveSpeed;
   [SerializeField] private float _jumpForce;
   [SerializeField] private float _checkRadius;
   [SerializeField] private Transform _checkGround;
   [SerializeField] private LayerMask _ground;

   public event Action<int> ScoreCoinsChanged;

   private Animator _animator;
   private SpriteRenderer _sprite;
   private Rigidbody2D _rigitBody;
   private Vector3 _vector;
   private bool _onGround;
   private bool _hasSecondJump;
   private int _currentCoin;

   public void AddCoin(int coin)
   {
      _currentCoin += coin;
      ScoreCoinsChanged?.Invoke(_currentCoin);
   }

   private void Start()
   {
      _animator = GetComponent<Animator>();
      _sprite = GetComponent<SpriteRenderer>();
      _rigitBody = GetComponent<Rigidbody2D>();
      _currentCoin = 0;
   }

   private void Update()
   {
      Run();
      Flip();
      CheckGround();
      Jump();
   }

   private void Run()
   {
      _vector = new Vector3(Input.GetAxis("Horizontal"), 0);
      transform.position += _vector * _moveSpeed * Time.deltaTime;
      _animator.SetFloat("moveHorisontal", Mathf.Abs(_vector.x));
   }

   private void Jump()
   {
      if (Input.GetKeyDown(KeyCode.Space) && _onGround)
      {
         _rigitBody.velocity = new Vector2(_rigitBody.velocity.x, _jumpForce);
      }
   }

   private void CheckGround()
   {
      _onGround = Physics2D.OverlapCircle(_checkGround.position, _checkRadius, _ground);
      _animator.SetBool("onGround", _onGround);
   }

   private void Flip() => _sprite.flipX = _vector.x < 0;

}
