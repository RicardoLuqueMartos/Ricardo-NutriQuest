using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemData : ScriptableObject
{
    #region Variables
    [Header("== Item ==")]

    [SerializeField]
    Texture2D icon;
    public Texture2D _icon { get { return icon; } }

    [SerializeField]
    string Name;
    public string _Name { get  { return Name; } }

    [SerializeField]
    float dropChange = 0; // on 100, chance that an enemy drop it for the player
    public float _dropChange { get { return dropChange; } }

    [SerializeField]
    GameObject ItemPrefab;
    public GameObject _ItemPrefab { get { return ItemPrefab; } }

    #endregion Variables


}
