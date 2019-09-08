using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;


namespace InventorySystem
{
    namespace Items
    {
        namespace Equipment
        {
            public class EquipmentManager : MonoBehaviour
            {


                #region singleton
                public static EquipmentManager instance;

                void Awake()
                {
                    if (instance != null)
                        Debug.LogWarning("more than one equipManager instance");

                    instance = this;


                }

                #endregion

                public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
                public OnEquipmentChanged onEquipmentChanged;


                //public SkinnedMeshRenderer targetMesh;

                public Equipment[] defualtEquipment;

                public Equipment[] currentEquipment;
                //SkinnedMeshRenderer[] currentMeshes;
                Inventory inventory;

                void Start()
                {
                    inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

                    int numOfSlots = System.Enum.GetNames(typeof(equipmentSlot)).Length;
                    currentEquipment = new Equipment[numOfSlots];
                    //currentMeshes = new SkinnedMeshRenderer[numOfSlots];

                    EquipDefaultItems();

                }

                public void Equip(Equipment newItem)
                {
                    int slotIndex = (int)newItem.equipSlot;
                    Equipment oldItem = UnEquip(slotIndex);


                    currentEquipment[slotIndex] = newItem;

                    //SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
                    //newMesh.transform.parent = targetMesh.transform;
                    // make changes so this equips to the right bones eg hand head etc
                    // newMesh.bones = targetMesh.bones;
                    // newMesh.rootBone = targetMesh.rootBone;

                    // currentMeshes[slotIndex] = newMesh;

                    if (onEquipmentChanged != null)
                    {
                        onEquipmentChanged.Invoke(newItem, oldItem);
                    }
                }

                void EquipDefaultItems()
                {
                    foreach (Equipment item in defualtEquipment)
                    {
                        Equip(item);
                    }
                }

                public Equipment UnEquip(int slotIndex)
                {
                    if (currentEquipment[slotIndex] != null)
                    {

                        // if (currentMeshes[slotIndex] != null)
                        // {
                        //     Destroy(currentMeshes[slotIndex].gameObject);
                        // }
                        Equipment oldItem = currentEquipment[slotIndex];
                        inventory.AddItem(oldItem);



                        currentEquipment[slotIndex] = null;

                        if (onEquipmentChanged != null)
                        {
                            onEquipmentChanged.Invoke(null, oldItem);
                        }
                        return oldItem;
                    }
                    return null;
                }

                public void UnEquipAll()
                {
                    for (int i = 0; i < currentEquipment.Length; i++)
                    {
                        UnEquip(i);
                    }

                    EquipDefaultItems();
                }

                void Update()
                {
                    if (Input.GetKeyDown(KeyCode.U))
                    {
                        UnEquipAll();
                    }
                }
            }
        }
    }
}
