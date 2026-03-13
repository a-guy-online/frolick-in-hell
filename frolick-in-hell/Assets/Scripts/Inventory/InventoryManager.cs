using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//8:32

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;

    public List<Slots> Inventory = new List<Slots>();

    private GameObject[] Slots;

    public InventoryItemData addItem;
    public InventoryItemData removeItem;

    #region inventory functions
    public bool AddItem(InventoryItemData item)
    {
        //Inventory.Add(item);

        Slots slot = Contains(item);
        if (slot != null)
        {
            slot.AddQuantity(1);
        } else
        {
            if (Inventory.Count < Slots.Length)
            {
                Inventory.Add(new Slots(item, 1));
            } else
            {
                return false;
            }
        }

        updateUI();
        return true;
    }

    public bool RemoveItem(InventoryItemData item)
    {

        Slots slot = Contains(item);
        if (slot != null)
        {
            slot.SubQuantity(1);
            if (slot.GetQuantity() < 1) {
                Slots slotRemove = new Slots();
                foreach (Slots slotCheck in Inventory)
                {
                    if (slot.GetItem() == item)
                    {
                        slotRemove = slotCheck;
                        break;
                    }
                }
                Inventory.Remove(slotRemove);
            }
        }
        else
        {
            return false;
        }

        //Inventory.Remove(item);
        
        updateUI();
        return true;
    }

    public Slots Contains(InventoryItemData item)
    {
        foreach(Slots slot in Inventory)
        {
            if (slot.GetItem() == item) {
                return (slot);
            }
        }
        return null;
    }

    #endregion

    #region UI updates
    public void updateSlots()
    {
        Slots = new GameObject[slotHolder.transform.childCount];
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
            Slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }
        updateUI();
    }

    public void updateUI()
    {
        for(int i = 0; i < Slots.Length; i++)
        {
            try
            {
                Slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                Slots[i].transform.GetChild(1).GetComponent<Text>().text = Inventory[i].GetQuantity() + "";
                Slots[i].GetComponent<Image>().enabled = true;
                Slots[i].transform.GetChild(0).GetComponent<Image>().sprite = Inventory[i].GetItem().icon;
            }
            catch
            {
                Slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                Slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
                Slots[i].GetComponent<Image>().enabled = false;
                Slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                
            }
            
        }
    }
    #endregion

    #region start update
    // Start is called before the first frame update
    void Start()
    {
        updateSlots();
        AddItem(addItem);
        AddItem(addItem);
        RemoveItem(removeItem);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
}
