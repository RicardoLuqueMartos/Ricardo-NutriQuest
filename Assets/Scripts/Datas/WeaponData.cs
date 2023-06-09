using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponData : ItemData
{
    #region Variables
    [Header("== As Weapon ==")]

    [SerializeField]
    bool autoFire;
    public bool _autoFire { get { return autoFire; } }

    [SerializeField]
    float fireRate;
    public float _fireRate { get { return fireRate; } }

    [SerializeField]
    float fastFireRate;
    public float _fastFireRate { get { return fastFireRate; } }

    [SerializeField]
    float turboFireRate;
    public float _turboFireRate { get { return turboFireRate; } }

    [SerializeField]
    int damage;
    public int _damage { get { return damage; } }

    [SerializeField]
    int criticalChance = 5; // on 100
    public int _criticalChance { get { return criticalChance; } }

    [SerializeField]
    float criticalMultiplicator = 2;
    public float _criticalMultiplicator { get { return criticalMultiplicator; } }

    [SerializeField]
    GameObject weaponPrefab;
    public GameObject _weaponPrefab { get { return weaponPrefab; } }

    [SerializeField]
    GameObject projectilePrefab;
    public GameObject _projectilePrefab { get { return projectilePrefab; } }

    #endregion Variables


}
