using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Variables
    [SerializeField]
    PlayerController playerController;

    public enum InputsEnum
    {
        None,
        Horizontal,
        Vertical,
        Fire1,
        Fire2,
        space,
        mouseScroll
    }

    #endregion Variables

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
    }
}
