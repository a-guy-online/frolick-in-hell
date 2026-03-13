using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Slots
{
    [SerializeField] private InventoryItemData item;
    [SerializeField] private int quantity;


    public Slots()
    {
        item = null;
        quantity = 0;
    }

    public Slots(InventoryItemData _item, int _quantity)
    {
        item = _item;
        quantity = _quantity;
    }

    public InventoryItemData GetItem() { return item; }
    public int GetQuantity() { return quantity;  }
    public void AddQuantity(int _amount) { quantity += _amount; }
    public void SubQuantity(int _amount) { quantity -= _amount; }

}
