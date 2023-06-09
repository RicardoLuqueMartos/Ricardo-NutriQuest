using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupData : ScriptableObject
{
    #region Variables

    [SerializeField]
    ItemData m_itemToPickup;
    public ItemData _itemToPickup { get { return m_itemToPickup; } }

    [SerializeField]
    bool m_destroyIfPick = true;
    public bool _destroyIfPick { get { return m_destroyIfPick; } }

    [SerializeField]
    float m_respawnAfterDelay = 0;
    public float _respawnAfterDelay { get { return m_respawnAfterDelay; } }

    #endregion Variables


}
