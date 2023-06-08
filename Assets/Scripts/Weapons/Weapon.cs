using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour//, IAttackWeapon
{
    [SerializeField]
    PlayerController m_playerController;

    [SerializeField]
    GameObject weaponSpawner;

    [SerializeField]
    GameObject weaponSpawnedObject;


    private void OnEnable()
    {
        SpawnActualWeapon(0);
    }

    #region Weapon & fire
    public void RemoveActualWeapon()
    {
        if (weaponSpawnedObject != null)
            Destroy(weaponSpawnedObject);
    }

    public void SpawnActualWeapon(int index)
    {
        weaponSpawnedObject = (GameObject)Instantiate(m_playerController._playerData._weapons._weaponsList[index]._weaponPrefab,
            weaponSpawner.transform.position, weaponSpawner.transform.rotation, weaponSpawner.transform);
        weaponSpawnedObject.GetComponent<WeaponBehaviour>().ByPlayer(m_playerController);
        weaponSpawnedObject.GetComponent<WeaponBehaviour>().Unlock();
        weaponSpawnedObject.GetComponent<WeaponBehaviour>().OnEnable();
    }


    #endregion Weapon & fire
}
