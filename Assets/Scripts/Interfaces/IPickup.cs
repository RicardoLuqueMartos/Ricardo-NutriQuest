using UnityEngine;

public interface IPickup : IAction
{
    void OnTriggerEnter(Collider other);

}