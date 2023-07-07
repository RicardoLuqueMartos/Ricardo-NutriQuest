using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : Jump
{
    
    [SerializeField]
    InputManager.InputsEnum m_Input = InputManager.InputsEnum.Fire2;
    public InputManager.InputsEnum _Input { get { return m_Input; } }

    void Update()
    {
        if (((m_Input == InputManager.InputsEnum.Fire2 || m_Input == InputManager.InputsEnum.Fire1)
            && UnityEngine.Input.GetButtonUp(_Input.ToString()))
            || (m_Input == InputManager.InputsEnum.space
            && UnityEngine.Input.GetKey(_Input.ToString()))   
            || (m_Input == InputManager.InputsEnum.Vertical
            && UnityEngine.Input.GetAxis(_Input.ToString()) > 0)
            )
            Jump();        
    }
        
    public void Jump() 
    {
        Debug.Log("Jump");
       VerifyAction();
    }
}
