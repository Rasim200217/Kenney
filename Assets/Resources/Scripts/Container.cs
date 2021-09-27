using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    private SpriteRenderer _render;
    private GameObject _itemPref;
    private bool _canUse;

    public Item.Items _thisItem = Item.Items.Coin;

    Inventory _inv;

    private void Start()
    {
        _render = GetComponent<SpriteRenderer>();
        _itemPref = Resources.Load<GameObject>("Prefabs/Item coin");
        
    }

    private void Update()
    {
        if (_canUse && Input.GetKeyDown(KeyCode.E))
        {
            GiveItem();
        }
    }

    private void GiveItem()
    {
        _inv.RemoveItem(1);
        Item temp = Instantiate(_itemPref, new Vector2(transform.position.x, transform.position.y + 1f), Quaternion.identity).GetComponent<Item>();
        temp.Settings(_thisItem);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _inv = collision.GetComponent<Inventory>();
            if (_inv._chestKeys > 0)
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
