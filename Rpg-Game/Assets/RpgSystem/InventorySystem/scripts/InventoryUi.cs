using UnityEngine;

namespace InventorySystem
{
    public class InventoryUi : MonoBehaviour
    {
        public GameObject inventoryUi;
        Inventory inventory;
        public Transform InventoryUISlotsParent;
        InventoryUISlot[] InventoryUISlots;
        // Use this for initialization
        void Start()
        {
            //need to refactor so this can take in any inventory not just the players
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            inventory.OnItemChangedCallBack += UpdateUI;

            InventoryUISlots = InventoryUISlotsParent.GetComponentsInChildren<InventoryUISlot>();
        }

        void UpdateUI()
        {
            Debug.Log("updating ui");
            for (int i = 0; i < InventoryUISlots.Length; i++)
            {
                if (i < inventory.items.Count)
                {
                    InventoryUISlots[i].AddItem(inventory.items[i]);
                }
                else
                {
                    InventoryUISlots[i].ClearSlot();
                }
            }
        }
    }
}
