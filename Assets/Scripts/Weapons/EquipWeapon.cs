using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour, IEquipWeapon
{
    #region Variables
    [SerializeField]
    PlayerController m_playerController;

    [SerializeField]
    InventoryManager m_inventoryManager;

    [SerializeField]
    GameObject weaponSpawner;

    [SerializeField]
    GameObject weaponSpawnedObject;
    public GameObject _weaponSpawnedObject { get { return weaponSpawnedObject; } }

    public GameObject GetSpawnedObject() { return weaponSpawnedObject; }

    [SerializeField]
    WeaponData m_equipedweapon;
    public WeaponData _equipedweapon { get { return m_equipedweapon; } }

    #endregion Variables

    private void OnEnable()
    {
        if (m_inventoryManager._weaponsList.Count > 0)
            SpawnActualWeapon(FindActualWeapon(0));
    } 

    void Update()
    {
        UpdateChangeWeapon();
    }

    void UpdateChangeWeapon()
    {
        Vector2 switchWeaponInput = Input.mouseScrollDelta;
        if (switchWeaponInput == new Vector2(0, 1))
        {
            Debug.Log("EquipNextWeapon");
            EquipNextWeapon();
        }
        if (switchWeaponInput == new Vector2(0, -1))
        {
            Debug.Log("EquipPreviousWeapon");
            EquipPreviousWeapon();
        }
    }

    public WeaponData FindActualWeapon(int index)
    {
        return m_inventoryManager._weaponsList[index];    
    }

    public void EquipNextWeapon()
    {
        int index = m_inventoryManager._weaponsList.IndexOf(m_equipedweapon);

        if (index < m_inventoryManager._weaponsList.Count)
        {
            index++;
        }
        else index = 0;

        EquipingWeapon(m_inventoryManager._weaponsList[index]);
    }

    public void EquipPreviousWeapon()
    {
        int index = m_inventoryManager._weaponsList.IndexOf(m_equipedweapon);

        if (index > 0)
        {
            index--;
        }
        else if (m_inventoryManager._weaponsList.Count > 0) index = m_inventoryManager._weaponsList.Count-1;

        EquipingWeapon(m_inventoryManager._weaponsList[index]);
    }

    public void EquipingWeapon(WeaponData weapon)
    {       
        RemoveActualWeapon();
        SpawnActualWeapon(weapon);
    }

    public void RemoveActualWeapon()
    {
        if (weaponSpawnedObject != null)
            Destroy(weaponSpawnedObject);
    }

    public void SpawnActualWeapon(WeaponData weapon)
    {
        weaponSpawnedObject = (GameObject)Instantiate(weapon._weaponPrefab,
            weaponSpawner.transform.position, weaponSpawner.transform.rotation, weaponSpawner.transform);
        weaponSpawnedObject.GetComponent<WeaponBehaviour>().ByPlayer(m_playerController);
        weaponSpawnedObject.GetComponent<WeaponBehaviour>().Unlock();
        weaponSpawnedObject.GetComponent<WeaponBehaviour>().OnEnable();
    }
}
