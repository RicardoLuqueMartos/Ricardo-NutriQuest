using System;
using System.Collections;
using System.Collections.Generic;
using TNRD;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : CharacterController
{
  
    [Header("== Player Controller ==")]
    
    [SerializeField]
    PlayerData playerData;
    public PlayerData _playerData { get { return playerData; } }
 
   
    [SerializeField]
    bool gamStarted = false;
      

    public void Death()
    {
        Debug.Log("dead");
    }
 
}
