using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    Text[] _counts;
    Image _doorKey;

   public static HUDManager _hudManager;

    private void Start()
    {
        Access();
    }

    private void Access()
    {

        _hudManager = this;
        _counts = new Text[4];

        for (int i = 0; i < _counts.Length; i++)
        {
            _counts[i] = transform.GetChild(i).GetChild(0).GetComponent<Text>();
        }

        _doorKey = transform.GetChild(4).GetComponent<Image>();
    }

    public void UpdateHud(Inventory inventory)
    {
        _counts[0].text = "x" + inventory._coins.ToString();
        _counts[1].text = "x" + inventory._chestKeys.ToString();
        _counts[2].text = "x" + inventory._swords.ToString();
        _counts[3].text = "x" + inventory._shields.ToString();

        if (inventory._doorKey)
        {
            _doorKey.sprite = Resources.Load<Sprite>("Sprites/HUD/hud_keyYellow");
        }
        else
        {
            _doorKey.sprite = Resources.Load<Sprite>("Sprites/HUD/hud_keyYellow_disabled");
        }
    }
}
