using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Move : MonoBehaviour, IMove
{
    [SerializeField] private float m_speed = 5f;

    [SerializeField] Animator m_playerAnimations;

    protected float horizontalInput = 0;
    protected float verticalInput = 0;

    [SerializeField] private Vector2 m_moveVector;
   
    float m_movementMagnitude;

    [SerializeField]
    CharacterController m_characterController;

    [SerializeField]
    float actualSpeed = 1.0f;

    void Start()
    {
        actualSpeed = m_characterController._characterData._mediumMoveSpeed;
    }   

    public void VerifyAction()
    {
        // here are conditions
        if (horizontalInput != 0 || verticalInput != 0)
        {
            m_moveVector = new Vector2(horizontalInput, verticalInput);

            LaunchAction();
        }
        else
        {
            m_movementMagnitude = 0;

            StopAnimation();
        }
    }

    public void LaunchAction() {

        // Move the player
        Vector3 direction = new Vector3(m_moveVector.x, 0, m_moveVector.y);
        m_characterController._rigidbody.velocity = direction * m_speed + m_characterController._rigidbody.velocity.y * Vector3.up;
       
        m_movementMagnitude = direction.magnitude;

        PlayAnimation();

        // Rotate the player
        if (direction != Vector3.zero)
        {
            m_characterController._rigidbody.rotation = Quaternion.LookRotation(direction);
        }
    }

    public void StopAction()
    {

    }

    public void PlayAnimation() {

        m_characterController._animator.SetFloat("Speed", m_movementMagnitude);        
    }

    public void StopAnimation()
    {
        m_characterController._animator.SetFloat("Speed", 0);
    }

    public void PlayAudio() { }
}
