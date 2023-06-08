using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour, IEquipWeapon
{
    [SerializeField]
    PlayerController m_playerController;

    [SerializeField]
    GameObject weaponSpawner;

    [SerializeField]
    GameObject weaponSpawnedObject;
    public GameObject _weaponSpawnedObject { get { return weaponSpawnedObject; } }

    public GameObject GetSpawnedObject() { return weaponSpawnedObject; }

    [SerializeField]
    WeaponData m_equipedweapon;
    public WeaponData _equipedweapon { get { return m_equipedweapon; } }

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
        m_equipedweapon = m_playerController._playerData._weapons._weaponsList[index];

        weaponSpawnedObject = (GameObject)Instantiate(m_playerController._playerData._weapons._weaponsList[index]._weaponPrefab,
            weaponSpawner.transform.position, weaponSpawner.transform.rotation, weaponSpawner.transform);
        weaponSpawnedObject.GetComponent<WeaponBehaviour>().ByPlayer(m_playerController);
        weaponSpawnedObject.GetComponent<WeaponBehaviour>().Unlock();
        weaponSpawnedObject.GetComponent<WeaponBehaviour>().OnEnable();
    }

    public void EquipNextWeapon()
    {
        int index = m_playerController._playerData._weapons._weaponsList.IndexOf(m_equipedweapon);

        if (index < m_playerController._playerData._weapons._weaponsList.Count-1)
        {
            index++;
        }
        else index = 0;

        RemoveActualWeapon();
        SpawnActualWeapon(index);
    }
    #endregion Weapon & fire
}
