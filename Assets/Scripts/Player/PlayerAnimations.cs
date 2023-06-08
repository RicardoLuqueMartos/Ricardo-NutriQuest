using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator m_playerAnimator;
    [SerializeField] Animator m_swordAnimator;

    public void Move(float movementMagnitude)
    {
        m_playerAnimator.SetFloat("Speed", movementMagnitude);
    }

    public void Attack()
    {
        m_swordAnimator.SetTrigger("Attack");
    }
}
