using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TNRD;

// Handles player input
public class JuPlayerController : MonoBehaviour
{

    [SerializeField] private SerializableInterface<IMove> m_playerMovementInterface;
    private IMove m_playerMovement => m_playerMovementInterface.Value;

    [SerializeField] private SerializableInterface<IAttack> m_playerAttackInterface;
    private IAttack m_playerAttack => m_playerAttackInterface.Value;

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
        m_playerMovement.Move(new Vector2(horizontalInput, verticalInput));        
    }

    void UpdateAttack()
    {       
        bool attackInput = Input.GetButtonDown("Fire1");
        if (attackInput)
        {
        //    m_playerAttack.Attack();
        }

        bool switchWeaponInput = Input.GetButtonDown("Fire2");
        if (switchWeaponInput)
        {
         //   m_playerAttack.ChangeWeapon();
        }
    }
}
