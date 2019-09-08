using System;
using System.Collections;
using System.Collections.Generic;
using InventorySystem.Items;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        // #region singleton
        // public static Inventory instance;

        // void Awake()
        // {
        //     if (instance != null)
        //         Debug.LogWarning("more than one inventory instance");

        //     instance = this;
        // }

        // #endregion

        public delegate void OnItemChanged();
        public OnItemChanged OnItemChangedCallBack;


        public List<Item> items = new List<Item>();
        public int InventoryCap = 20;

        public bool AddItem(Item item)
        {
            if (!item.isDefualtItem)
            {
                if (items.Count >= InventoryCap)
                {
                    return false;
                }

                items.Add(item);
                item.inventoryCurrentlyIn = this;
                if (OnItemChangedCallBack != null)
                    OnItemChangedCallBack.Invoke();
            }
            return true;
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
            item.inventoryCurrentlyIn = null;

            if (OnItemChangedCallBack != null)
                OnItemChangedCallBack.Invoke();
        }

    }
}
