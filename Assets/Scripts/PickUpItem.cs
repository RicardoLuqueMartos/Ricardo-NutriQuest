using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour, IPickable
{
    #region Variables
    

    [SerializeField]
    PickupData m_pickupData;
    public PickupData _pickupData { get { return m_pickupData; } }


    #endregion Variables
    public void PickMeUp(InventoryManager inventoryManager)
    {
        inventoryManager.AddAweapon(_pickupData._itemToPickup as WeaponData);
    }
    public void PickupDone()
    {
        if (m_pickupData._destroyIfPick) DestroyPickup();
    }

    public void DestroyPickup()
    {
        Destroy(gameObject);
    }

}
