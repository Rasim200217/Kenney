using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public int _coins = 0;
    public int _chestKeys = 0;
    public int _swords = 0;
    public int _shields = 0;
    public bool _doorKey;

    private GameObject _mySword;
    private GameObject _myShield;

    private void Start()
    {
        _mySword = transform.GetChild(0).gameObject;
        _myShield = transform.GetChild(1).gameObject;
    }

    public void AddItem(int id)
    {
        switch (id)
        {
            case 0: _coins++; break;
            case 1: _chestKeys++; break;
            case 2: _swords++; CheckMySword(); break;
            case 3: _shields++; CheckMyShield(); break;
            case 4: _doorKey = true; break;
        }
        HUDManager._hudManager.UpdateHud(this);
    }

    public void RemoveItem(int id)
    {
        switch (id)
        {
            case 0: _coins--; break;
            case 1: _chestKeys--; break;
            case 2: _swords--; CheckMySword();  break;
            case 3: _shields--; CheckMyShield(); break;
            case 4: _doorKey = false; break;
        }
        HUDManager._hudManager.UpdateHud(this);
    }
   
     void CheckMySword()
    {
        if (_swords > 0) _mySword.SetActive(true);
        else _mySword.SetActive(false);
    }
    void CheckMyShield()
    {
        if (_shields > 0) _myShield.SetActive(true);
        else _myShield.SetActive(false);
    }

}
