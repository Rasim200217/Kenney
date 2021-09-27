using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInterective : MonoBehaviour
{
    private bool _isDead = false;
    private bool _canDie = true;
    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<Inventory>() || _isDead) return;

            Inventory inv = collision.GetComponent<Inventory>();
            CanDie cd = collision.GetComponent<CanDie>();

        if (inv._swords > 0 && _canDie)
        {
            inv.RemoveItem(2);
            _isDead = true;
            _animator.SetBool("Die", true);
            Destroy(gameObject, 0.6f);
            return;
        }

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

    public bool GetDeadIsState()
    {
        return _isDead;
    }
}
