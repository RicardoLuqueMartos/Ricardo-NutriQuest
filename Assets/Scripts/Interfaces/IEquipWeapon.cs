
using UnityEngine;

public interface IEquipWeapon
{
    void RemoveActualWeapon();
    WeaponData FindActualWeapon(int index);

    GameObject GetSpawnedObject();

    void EquipNextWeapon();

    void EquipPreviousWeapon();
    void EquipingWeapon(WeaponData weapon);
    void SpawnActualWeapon(WeaponData weapon);

}
