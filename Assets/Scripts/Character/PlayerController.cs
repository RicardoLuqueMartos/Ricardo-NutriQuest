using System;
using System.Collections;
using System.Collections.Generic;
using TNRD;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : CharacterController
{
    /*   [SerializeField] private SerializableInterface<IAttack> m_playerAttackInterface;
       private IAttack m_playerAttack => m_playerAttackInterface.Value;

       [SerializeField] private SerializableInterface<IEquipWeapon> m_equipWeaponInterface;
       private IEquipWeapon m_equipWeapon => m_equipWeaponInterface.Value;
       */
    [Header("== Player Controller ==")]
    [SerializeField] private SerializableInterface<IMove> m_playerMovementInterface;
    private IMove m_playerMovement => m_playerMovementInterface.Value;
    public IMove _playerMovement { get { return m_playerMovement; } }


    [SerializeField]
    CharacterController characterController;

    [SerializeField]
    PlayerData playerData;
    public PlayerData _playerData { get { return playerData; } }
    
    [SerializeField]
    float actualSpeed = 1.0f;
    /*
    [SerializeField]
    GameObject weaponSpawner;

    [SerializeField]
    GameObject weaponSpawnedObject;
    */
    [SerializeField]
    bool gamStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        actualSpeed = playerData._mediumMoveSpeed;
    }
    /*
    private void OnEnable()
    {
        SpawnActualWeapon(0);        
    }*/

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
    }
    private void UpdateInput()
    {
        HandlePlayerMovment();
    }

    public void Death()
    {
        Debug.Log("dead");
    }
    #region Movement
    void HandlePlayerMovment()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.back * (Time.deltaTime * actualSpeed));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * actualSpeed));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * (Time.deltaTime * actualSpeed));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * (Time.deltaTime * actualSpeed));
        }
    }
    #endregion Movement

}
