using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemyController : CharacterController
{
    #region Variables
    [HideInInspector]
    public Transform PlayerPosition;

    [SerializeField]
    private Renderer _EnnemyRenderer;
  

    #endregion Variables

    private void OnEnable()
    {
        LifePoint = _enemyData._maxHitPoints;
       
    }
    private void OnDisable()
    {
       
    }

    void Update()
    {
        if (transform != null && _enemyData._moveType == EnemyData.MoveTypeEnum.RushOnPlayer)
            AimAndRushPlayer();
    }

    void AimAndRushPlayer()
    {
        if (transform != null)
        {
            Vector3 dest = Vector3.Normalize(PlayerPosition.position - transform.position);
            transform.Translate(dest * _enemyData._mediumMoveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //   Debug.Log("collision");
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Destroy(gameObject);
        }
    }

    public void Explode()
    {
        Debug.Log("Explode");
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        _EnnemyRenderer.enabled = false;
        Destroy(gameObject, ps.main.duration);
    }
}
