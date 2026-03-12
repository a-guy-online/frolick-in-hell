using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//8:32

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;

    public List<InventoryItemData> Inventory = new List<InventoryItemData>();

    private GameObject[] Slots;

    public void AddItem(InventoryItemData item)
    {
        Inventory.Add(item);
    }

    public void RemoveItem(InventoryItemData item)
    {
        Inventory.Remove(item);
    }

    public void updateSlots()
    {
        Slots = new GameObject[slotHolder.transform.childCount];
    }

    #region start update
    // Start is called before the first frame update
    void Start()
    {
        updateSlots();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
}
