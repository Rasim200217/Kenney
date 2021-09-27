using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce = 50f;
    [SerializeField] private int _frameForJump = 10;

    private int frame;

    private bool _facingRight = true;
    private bool _isGrounded;
    private bool _canJump;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move(); // Движение
        Jump(); // Прыжок

        if (_canJump)
        {
            FrameChecker(); // Высокий прыжок
        }
        AnimatorState(); // Анимация
    }

    // Движение
    private void Move()
    {
        float x = Input.GetAxis("Horizontal");

        _rigidbody.velocity = new Vector2(x * _speed, _rigidbody.velocity.y);

        if (_facingRight && x < 0)
        {
            Flip();
        }
        if (!_facingRight && x > 0)
        {
            Flip();
        }
    }

    // Хранилище анимации
    private void AnimatorState()
    {
        // Анимация прыжка
        _animator.SetBool("isJump", !_isGrounded);

        bool _walk;  

        // Анимация бега
        if (Input.GetAxis("Horizontal") != 0)
        {
            _walk = true;
        }
        else
        {
            _walk = false;
        }
        _animator.SetBool("isWalk", _walk);
    }

    // Поворот персонажа
    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 temp = transform.localScale;
        temp.x *= -1;

        transform.localScale = temp;
    }

    // Прыжок персонажа
    private void Jump()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                _isGrounded = false;
                _canJump = true;
            }
            if (_canJump)
            {
                _rigidbody.AddForce(new Vector2(0, _jumpForce));  
            }    
        }    
    }


    // Проверка земли
    public void OnGround(bool ground)
    {
            _isGrounded = ground;
    }

    // Проверка до макс кадра
    public void FrameChecker()
    {
        if (frame >= _frameForJump)
        {
            _canJump = false;
            frame = 0;
        }
        frame++;
    }
}
