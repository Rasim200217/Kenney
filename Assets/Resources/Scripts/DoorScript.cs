using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    private SpriteRenderer _render;

    private string[] _scenesNames;

    public enum Levels {
        Menu = 0,
        Level0 = 1,
        Level1 = 2,
        Level2 = 3,
        Level3 = 4
    }

    public Levels newLevel = Levels.Menu;

    Inventory _inv;

    private bool _canUse;

    private void Start()
    {
        _render = GetComponent<SpriteRenderer>();
        SetSceneNames();
    }

    private void Update()
    {
        if (_canUse && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(_scenesNames[(int)newLevel]);
        }
    }

    private void SetSceneNames()
    {
        _scenesNames = new string[5];
        _scenesNames[0] = "Menu";
        _scenesNames[1] = "Level 1";
        _scenesNames[2] = "Level 2";
        _scenesNames[3] = "Level 3";
        _scenesNames[4] = "Level 4";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _inv = collision.GetComponent<Inventory>();
            if (_inv._doorKey)
            {
                Color temp = _render.color;
                temp.a = 0.6f;
                _render.color = temp;

                _canUse = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Color temp = _render.color;
            temp.a = 1f;
            _render.color = temp;

            _inv = null;
            _canUse = false;
        }
    }
}
