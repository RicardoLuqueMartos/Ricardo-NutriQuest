using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Moves the player character
public class PlayerMovement : MonoBehaviour, IMove
{
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private float m_speed = 5f;

    [SerializeField] PlayerAnimations m_playerAnimations;

    public void Move(Vector2 input)
    {
        // Move the player
        Vector3 direction = new Vector3(input.x, 0, input.y);
        m_rigidbody.velocity = direction * m_speed + m_rigidbody.velocity.y * Vector3.up;

        m_playerAnimations.Move(direction.magnitude);

        // Rotate the player
        if (direction != Vector3.zero)
        {
            m_rigidbody.rotation = Quaternion.LookRotation(direction);
        }
    }
}
