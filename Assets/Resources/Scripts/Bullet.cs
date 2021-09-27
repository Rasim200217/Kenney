using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed;
    public float _mySpeed;
    public bool _isLeft;

    public void Settings(float speed, bool left, float lifeTime)
    {
        Destroy(gameObject, lifeTime);

        _mySpeed = speed;
        _isLeft = left;

        if (_isLeft)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
         
    }

    private void FixedUpdate()
    {
        if (_isLeft)
            transform.position += new Vector3(_mySpeed * .01f, 0);
        else
            transform.position -= new Vector3(_mySpeed * .01f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<Inventory>()) return;

        Inventory inv = collision.GetComponent<Inventory>();
        CanDie cd = collision.GetComponent<CanDie>();

        if (inv._shields > 0 && !cd._immortal)
        {
            inv.RemoveItem(3);
            cd.ShieldUsed();
            return;
        }

        if (!cd._immortal)
        {
            cd.PlayerIsDead();
        }
    }
}
