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
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            inventory.OnItemChangedCallBack += UpdateUI;

            InventoryUISlots = InventoryUISlotsParent.GetComponentsInChildren<InventoryUISlot>();
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
            for (int i = 0; i < InventoryUISlots.Length; i++)
            {
                if (i < inventory.items.Count)
                {
                    InventoryUISlots[i].AddItem(inventory.items[i]);
                }
                else
                {
                    InventoryUISlots[i].RemoveItem();
                }
            }
        }
    }
}
