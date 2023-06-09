using UnityEngine;

public interface IPickup
{
    void OnTriggerEnter(Collider other);
    void Pickup();
}