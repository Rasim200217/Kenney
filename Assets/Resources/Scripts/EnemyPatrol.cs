using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private SpriteRenderer _facingFlip;

    [Range(0.01f, 1f)]
    [SerializeField] private float _speed;

    [Range(0.1f, 10f)]
    [SerializeField] private float _destination;
    private float _startPos, _endPos;

    private bool _facingLeft;

    private void Start()
    {
        _startPos = transform.position.x;
        _endPos = _startPos - _destination;

        _facingFlip = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (_facingLeft)
        {
            transform.position -= new Vector3(_speed, 0, 0);
        }

        if (transform.position.x <= _endPos)
        {
            _facingLeft = false;
            EnemyFlipX();
        }

        if (!_facingLeft)
        {
            transform.position += new Vector3(_speed, 0, 0);
        }

        if (transform.position.x >= _startPos)
        {
            _facingLeft = true;
            EnemyFlipX();
        }
    }


    private void EnemyFlipX()
    {
        if (_facingLeft) _facingFlip.flipX = false;
        else _facingFlip.flipX = true;
    }
}
