using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    void PickMeUp(InventoryManager inventoryManager);
    void PickupDone();
    void DestroyPickup();
}
