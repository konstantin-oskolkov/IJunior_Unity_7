using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
   [SerializeField] private float _speed;
   [SerializeField] private float _timeToWait;
   [SerializeField] private Vector3 _position;
   [SerializeField] private List<Transform> _points;

   private SpriteRenderer _sprite;
   private Coroutine _coroutine;
   private int _currentPoint;

   public void GetPath(List<Transform> points)
   {
      _points = points;
   }

   private void Start()
   {
      _sprite = GetComponent<SpriteRenderer>();
      _position = _points[_currentPoint].position;
   }

   private void Update()
   {
      if (transform.position.x != _position.x)
         Move();

      if (transform.position.x == _position.x)
         Wait();
   }

   private void Move()
   {
      if (_coroutine != null)
         StopCoroutine(_coroutine);

      transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, _position.x, _speed * Time.deltaTime), transform.position.y, transform.position.z);
   }

   private void Wait()
   {
      _coroutine = StartCoroutine(WaitTime());

      _currentPoint++;

      if (_currentPoint == _points.Count)
         _currentPoint = 0;
   }

   private void Flip() => _sprite.flipX = _position.x > transform.position.x;

   private IEnumerator WaitTime()
   {
      _position = transform.position;

      yield return new WaitForSeconds(_timeToWait);

      _position = _points[_currentPoint].position;

      Flip();
   }
}
