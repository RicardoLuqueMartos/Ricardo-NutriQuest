using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float m_maxHealth = 10f;

    private float m_currentHealth;

    private void Start()
    {
        m_currentHealth = m_maxHealth;
    }

    public void TakeDamage(float damage)
    {
        m_currentHealth -= damage;

        if (m_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
