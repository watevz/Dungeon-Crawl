using UnityEngine;
using InventorySystem;


namespace Interaction
{
    public class ItemPickup : Interactable
    {
        public Item item;

        bool wasPickedUp = false;

        protected override void CompleteInteract(Transform interactingObject)
        {
            base.CompleteInteract(interactingObject);
            Inventory interactingInventory = interactingObject.GetComponent<Inventory>();
            if (interactingInventory)
            {
                PickUp(interactingInventory);
                hasInteracted = true;
            }
        }

        void PickUp(Inventory interactingInventory)
        {
            wasPickedUp = interactingInventory.AddItem(item);
            if (wasPickedUp)
            {
                Destroy(gameObject);
            }
            Debug.Log("picked up", gameObject);

        }
    }
}
