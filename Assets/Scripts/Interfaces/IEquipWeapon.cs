
using UnityEngine;

public interface IEquipWeapon
{
    void RemoveActualWeapon();
    void SpawnActualWeapon(int index);

    GameObject GetSpawnedObject();

    void EquipNextWeapon();
}
