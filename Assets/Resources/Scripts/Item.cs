using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] int _id;

    SpriteRenderer _render;

    public enum Items
    {
        Coin = 0,
        ChestKey = 1,
        Sword = 2,
        Shield = 3,
        DoorKey = 4
    }

    public Items _thisItem = Items.Coin;

    private void Start()
    {
        Settings(_thisItem);
    }

    public void Settings(Items what)
    {
        _render = GetComponent<SpriteRenderer>();
        _thisItem = what;
        _id = GetId();
        Data();
    }

    private void Data()
    {
        switch (_id)
        {
            case 0: ThisCoin(); break;
            case 1: ThisСhestKey(); break;
            case 2: ThisSword(); break;
            case 3: ThisShield(); break;
            case 4: ThisDoorKey(); break;
        }
    }

    private void ThisCoin()
    {
        _render.sprite = Resources.Load<Sprite>("Sprites/Items/coinSprite");
        gameObject.name = "Coin";
    }

    private void ThisСhestKey()
    {
        _render.sprite = Resources.Load<Sprite>("Sprites/Items/chestKeySprite");
        gameObject.name = "ChestKey";
    }

    private void ThisSword()
    {
        _render.sprite = Resources.Load<Sprite>("Sprites/Items/swordSprite");
        gameObject.name = "Sword";
    }

    private void ThisShield()
    {
        _render.sprite = Resources.Load<Sprite>("Sprites/Items/shieldSprite");
        gameObject.name = "Shield";
    }

    private void ThisDoorKey()
    {
        _render.sprite = Resources.Load<Sprite>("Sprites/Items/goldKeySprite");
        gameObject.name = "DoorKey";
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Inventory>())
        {
            collision.GetComponent<Inventory>().AddItem(_id);
            Destroy(gameObject);
        }
    }

    int GetId()
    {
        return (int)_thisItem;
    }
}
