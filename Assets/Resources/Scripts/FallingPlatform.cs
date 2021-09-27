using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
  private Rigidbody2D _rigidbody;

  private void Start()
  {
    _rigidbody = GetComponent<Rigidbody2D>();
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      Invoke("FallPlatform", 1f);
      Destroy(gameObject, 2f);
    }
  }

  private void FallPlatform()
  {
    _rigidbody.isKinematic = false;
  }
  
}
