using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Variables
    [SerializeField]
    PlayerController playerController;

    #endregion Variables

    void Update()
    {
        UpdateMove();

        UpdateAttack();
    }

    void UpdateMove()
    {
        // Move input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerController._playerMovement.Move(new Vector2(horizontalInput, verticalInput));
    }

    void UpdateAttack()
    {
        bool attackInput = Input.GetButtonDown("Fire1");
        if (attackInput)
        {
            playerController._equipWeapon.GetSpawnedObject().GetComponent<WeaponBehaviour>().Fire(playerController);
        }

        bool switchWeaponInput = Input.GetButtonDown("Fire2");
        if (switchWeaponInput)
        {
            playerController._equipWeapon.EquipNextWeapon();
        }
    }
}
