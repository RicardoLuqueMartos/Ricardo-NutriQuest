using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TNRD;

// Makes the player attack
public class PlayerAttack : MonoBehaviour, IAttack
{
    /*    [Space(10)]
        [SerializeField] private SerializableInterface<IAttackWeapon>[] m_weapons;

        private int m_currentWeaponIndex = 0;
        */

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
    private void RemoveActualWeapon()
    {
        if (weaponSpawnedObject != null)
            Destroy(weaponSpawnedObject);
    }

    void SpawnActualWeapon(int index)
    {
        weaponSpawnedObject = (GameObject)Instantiate(m_playerController._playerData._weapons._weaponsList[index]._weaponPrefab,
            weaponSpawner.transform.position, weaponSpawner.transform.rotation, weaponSpawner.transform);
        weaponSpawnedObject.GetComponent<WeaponBehaviour>().ByPlayer(m_playerController);
        weaponSpawnedObject.GetComponent<WeaponBehaviour>().Unlock();
        weaponSpawnedObject.GetComponent<WeaponBehaviour>().OnEnable();
    }

    #endregion Weapon & fire
    /*
    public void Attack()
    {
        m_weapons[m_currentWeaponIndex].Value.Attack();
    }

    public void ChangeWeapon()
    {
        m_currentWeaponIndex = (m_currentWeaponIndex + 1) % 2;
    }*/
}
