using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour, IPickup
{
    #region Variables
    [SerializeField]
    PickUpItem m_pickUpItem = null;
   
    [SerializeField]
    InventoryManager m_inventoryManager;
    #endregion Variables

    public void OnTriggerEnter(Collider other)
    {
        m_pickUpItem = other.transform.GetComponent<PickUpItem>();
        if (m_pickUpItem != null) {
            VerifyAction();
        }
    }

    public void VerifyAction()
    {
        if (m_pickUpItem._pickupData._itemToPickup.GetType().ToString() == "WeaponData") 
            LaunchAction();

    }

    public void LaunchAction()
    {
        if (m_pickUpItem._pickupData._itemToPickup.GetType().ToString() == "WeaponData")
            m_inventoryManager.AddAweapon(m_pickUpItem._pickupData._itemToPickup as WeaponData);


        PlayAnimation();
        PlayAudio();
        m_pickUpItem.PickupDone();
    }

    public void StopAction()
    {

    }

    public void PlayAnimation()
    {

    }

    public void StopAnimation() { }

    public void PlayAudio()
    {

    }
}
