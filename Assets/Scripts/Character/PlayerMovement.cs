using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Moves the player character
public class PlayerMovement : Move
{
    [SerializeField]
    PlayerController m_playerController;

    [SerializeField]
    InputManager.InputsEnum m_horizontalInput = InputManager.InputsEnum.Horizontal;
    public InputManager.InputsEnum _horizontalInput { get { return m_horizontalInput; } }

    [SerializeField]
    InputManager.InputsEnum m_verticalInput = InputManager.InputsEnum.Vertical;
    public InputManager.InputsEnum _verticalInput { get { return m_verticalInput; } }

    public void Update()
    {
        Move();
    }

    public void Move()
    {
        horizontalInput = UnityEngine.Input.GetAxis(_horizontalInput.ToString());
    //    verticalInput = UnityEngine.Input.GetAxis(_verticalInput.ToString());
               
        VerifyAction();
    }
}
