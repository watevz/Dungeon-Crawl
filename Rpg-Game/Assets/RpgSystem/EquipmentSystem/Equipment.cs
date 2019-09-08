using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    namespace Items
    {
        namespace Equipment
        {
            [CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
            public class Equipment : Item
            {

                public int armourModifier = 0;
                public int damageModifier = 0;
                public equipmentSlot equipSlot;
                public SkinnedMeshRenderer mesh;
                public override void Use()
                {
                    base.Use();
                    inventoryCurrentlyIn.GetComponent<EquipmentManager>().Equip(this);
                    // EquipmentManager.instance.Equip(this);
                    RemoveFromInventory();
                }
            }

            public enum equipmentSlot { Head, Chest, Legs, Feet, MainHand, OffHand }
        }
    }
}
