using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour, IJump
{
    [SerializeField]
    protected CharacterController m_characterController;

    public float m_jumpForce = 10f;
    public float m_jumpDuration = 1.5f;
    [SerializeField]
    float m_jumpTimer = 0f;

    [SerializeField]
    protected bool m_jumping = false;

    public void FixedUpdate ()
    {
        if (m_jumping)
        {
            m_jumpTimer = m_jumpTimer + Time.deltaTime*1;
        }

        if (m_jumping && m_jumpTimer > m_jumpDuration)
        {
            StopAction();
        }

   /*     if (m_jumping && m_characterController.isGrounded)
        {
            StopAction();
        }*/
    }

    public void VerifyAction() {
     //   m_characterController.CheckIfGrounded();
        if (m_characterController.isGrounded && !m_jumping)
        {
            LaunchAction();
        }
    }

    public void LaunchAction() {
        m_characterController.jumping= true;

        m_jumpTimer = 0f;

        m_characterController._rigidbody.AddForce(m_characterController.transform.up * m_jumpForce);

        m_jumping = true;

        PlayAnimation();
    }

    public void StopAction()
    {
        m_characterController.jumping = false;

        m_jumping = false;
    //    m_characterController.isGrounded = true;
        StopAnimation();
    }

    public void PlayAnimation() {
        
    }

    public void StopAnimation() { }

    public void PlayAudio() { }
}
