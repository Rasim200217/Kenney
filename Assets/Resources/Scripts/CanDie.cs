using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanDie : MonoBehaviour
{
    SpriteRenderer _render;
    Color _color;


    public bool _immortal = false;

    private void Start()
    {
        _render = GetComponent<SpriteRenderer>();
        _color = _render.color;
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Traps"))
        {
            PlayerIsDead();
        }
    }

    public void PlayerIsDead()
    {
        Debug.Log("Ты умер");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ShieldUsed()
    {
        StartCoroutine(Immortal());
    }

    IEnumerator Immortal()
    {
        _immortal = true;
        _color.a = 0.6f;
        _render.color = _color;
        yield return new WaitForSeconds(2f);
        _color.a = 1f;
        _render.color = _color;
        _immortal = false;
    }
}

