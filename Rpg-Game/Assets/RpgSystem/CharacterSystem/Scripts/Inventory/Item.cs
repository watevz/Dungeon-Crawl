using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InventorySystem
{
        [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {

        public string itemName = "New Item";
        public Sprite icon = null;
        public bool isDefualtItem = false;

        public virtual void Use()
        {
            //use the item
        }

        public void RemoveFromInventory(Inventory inventory)
        {
            inventory.RemoveItem(this);
        }
    }
}
