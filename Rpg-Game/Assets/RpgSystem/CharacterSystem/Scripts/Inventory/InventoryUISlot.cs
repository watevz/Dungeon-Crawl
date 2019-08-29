using InventorySystem.Items;
using UnityEngine;
using UnityEngine.UI;


namespace InventorySystem
{
    public class InventoryUISlot : MonoBehaviour
    {

        Item item;
        Inventory inventory;
        public Image icon;
        public Button removeButton;

        void Start()
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        }

        public void AddItem(Item newItem)
        {
            item = newItem;
            icon.sprite = item.icon;
            icon.enabled = true;
            removeButton.interactable = true;
        }

        public void RemoveItem()
        {
            item = null;
            icon.sprite = null;
            icon.enabled = false;
            removeButton.interactable = false;
        }

        public void UseItem()
        {
            if (item != null)
            {
                item.Use();
            }
        }

        public void OnRemoveButton()
        {
            inventory.RemoveItem(item);
        }
    }
}
