using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{

    PlayerController _player;

    private void Start()
    {
        _player = transform.parent.GetComponent<PlayerController>();
    }

    // Стоит ли персонаж на земле
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            _player.OnGround(true);
        }
    }

    // Не стоит ли персонаж на земле
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            _player.OnGround(false);
        }
    }
}
