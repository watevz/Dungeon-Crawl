using UnityEngine;

namespace InventorySystem
{
    public class InventoryUi : MonoBehaviour
    {
        public GameObject inventoryUi;
        Inventory inventory;
        public Transform inventorySlotsParent;
        InventorySlot[] inventorySlots;
        // Use this for initialization
        void Start()
        {
            inventory = Inventory.instance;
            inventory.OnItemChangedCallBack += UpdateUI;

            inventorySlots = inventorySlotsParent.GetComponentsInChildren<InventorySlot>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Inventory"))
            {
                inventoryUi.SetActive(!inventoryUi.activeSelf);
            }
        }

        void UpdateUI()
        {
            Debug.Log("updateing ui");
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (i < inventory.items.Count)
                {
                    inventorySlots[i].AddItem(inventory.items[i]);
                }
                else
                {
                    inventorySlots[i].RemoveItem();
                }
            }
        }
    }
}
