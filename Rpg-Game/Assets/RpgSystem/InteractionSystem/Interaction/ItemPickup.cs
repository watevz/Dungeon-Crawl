using UnityEngine;


namespace Interaction
{
    public class ItemPickup : Interactable
    {

        //public Item item;

        bool wasPickedUp = false;

        public override void Interact()
        {
            base.Interact();

            PickUp();
        }

        void PickUp()
        {
            // wasPickedUp = Inventory.instance.AddItem(item);
            // if (wasPickedUp)
            //     Destroy(gameObject);
        }
    }
}
