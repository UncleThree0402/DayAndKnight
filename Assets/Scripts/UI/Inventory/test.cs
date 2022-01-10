using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;
    private void Awake()
    {
        inventory = new Inventory(UseItem);
        uiInventory.SetPlayer(this);
        uiInventory.SetInventory(inventory);
    }
    
    private void UseItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.drug:
                //useDrug;
                inventory.RemoveItem(new Item { itemType = Item.ItemType.drug,amount=1});
                break;
            case Item.ItemType.Shield:
                inventory.RemoveItem(item);
                break;
            case Item.ItemType.Sword:

                inventory.RemoveItem(item);
                break;
        }
    }
}
