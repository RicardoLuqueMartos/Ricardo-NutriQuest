using System;
using System.Collections;
using System.Collections.Generic;
using TNRD;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    #region Variable
    [SerializeField] private SerializableInterface<IEquipWeapon> m_equipWeaponInterface;
    private IEquipWeapon m_equipWeapon => m_equipWeaponInterface.Value;

    [SerializeField]
    List<WeaponData> m_weaponsList = new List<WeaponData>();
    public List<WeaponData> _weaponsList { get { return m_weaponsList; } }

    #endregion Variable

    public void AddAweapon(WeaponData weapon)
    {
        if (m_weaponsList.Contains(weapon) == false)
        {
            m_weaponsList.Add(weapon);

            m_equipWeapon.EquipingWeapon(weapon);
               
        }
    }
}
