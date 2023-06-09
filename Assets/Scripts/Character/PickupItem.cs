using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupItem : MonoBehaviour, IPickup
{
    #region Variables
    [SerializeField]
    PickMeUp m_pickMeUp = null;
   
    [SerializeField]
    InventoryManager m_inventoryManager;
    #endregion Variables

    public void OnTriggerEnter(Collider other)
    {
        m_pickMeUp = other.transform.GetComponent<PickMeUp>();
        if (m_pickMeUp != null) {
            Pickup();
        }
    }

    public void Pickup()
    {
        if (m_pickMeUp._pickupData._itemToPickup.GetType().ToString() == "WeaponData") PickWeapon();

   //     PickWeapon();

        m_pickMeUp.DestroyPickup();
    }

    public void PickWeapon()
    {
        Debug.Log("PickWeapon");
        m_inventoryManager.AddAweapon(m_pickMeUp._pickupData._itemToPickup as WeaponData);
    }

}
