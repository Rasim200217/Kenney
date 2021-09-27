using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
   [SerializeField] private float _speed;
   [SerializeField] private int _startPoint;
   [SerializeField] private Transform[] _points;

   private int _index;

   private void Start()
   {
      transform.position = _points[_startPoint].position;
   }

   private void Update()
   {
      if (Vector2.Distance(transform.position, _points[_index].position) < 0.2f)
      {
         _index++;
         if (_index == _points.Length)
         {
            _index = 0;
         }
      }

      transform.position = Vector2.MoveTowards(transform.position, _points[_index].position, _speed * Time.deltaTime);
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      other.transform.SetParent(transform);
   }

   private void OnCollisionExit2D(Collision2D other)
   {
      other.transform.SetParent(null);
   }
}



