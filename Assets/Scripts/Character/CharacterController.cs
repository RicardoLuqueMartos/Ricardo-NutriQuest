using System.Collections;
using System.Collections.Generic;
using TNRD;
using Unity.Android.Gradle;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class CharacterController : MonoBehaviour
{
    #region Variables
    [Header("== Character Controller ==")]

    

    #region Interfaces
    [SerializeField] private SerializableInterface<IEquipWeapon> m_equipWeaponInterface;
    private IEquipWeapon m_equipWeapon => m_equipWeaponInterface.Value;
    public IEquipWeapon _equipWeapon { get { return m_equipWeapon; } }

    [SerializeField] private SerializableInterface<IMove> m_movementInterface;
    private IMove m_move => m_movementInterface.Value;
    public IMove _move { get { return m_move; } }

   [SerializeField] private SerializableInterface<IJump> m_jumpInterface;
    private IJump m_jump => m_jumpInterface.Value;
    public IJump _jump { get { return m_jump; } }
    
    #endregion Interfaces

    [SerializeField]
    CharacterData m_characterData;
    public CharacterData _characterData { get { return m_characterData; } }

    [SerializeField]
    EnemyData enemyData;
    public EnemyData _enemyData { get { return enemyData; } }

    [SerializeField] private Rigidbody m_rigidbody;
    public Rigidbody _rigidbody { get { return m_rigidbody; } }

    [SerializeField]
    Animator animator;
    public Animator _animator { get { return animator; } }

    [SerializeField]
    bool IsPlayer = false;
    public bool _IsPlayer { get { return IsPlayer; } }

    [SerializeField]
    PlayerController playerController;

    [Header("== Character Values ==")]
    [SerializeField]
    protected int MaxLifePoint = 1;

    [SerializeField]
    protected int LifePoint = 1;

   

    enum HowDestroyEnum { DestroyObject, DisableComponent }
   
    [Header("== Character Rules ==")]
    [SerializeField]
    private HowDestroyEnum HowDestroy = new HowDestroyEnum();

    [Header("== Character Fx ==")]
    [SerializeField]
    private GameObject DestroyedFXPositionObj;

    [SerializeField]
    private AudioSource DestroyedSoundPlayer;

    [Header("Falling Values")]
    [SerializeField]
    public bool isGrounded = true;
    public float inAirTimer;
    public float leapingVelocity;
    public float fallingVelocity;
    public LayerMask groundLayer;
    public float raycastHeightOffset = 0.5f;
    public float colliderDelay = 0.1f;
    public float distance;
    public float yPosition = 0;
    public CapsuleCollider collider;
    public bool jumping = false;
    public float VerifyYPositionRate = 0.1f;
    [System.Serializable]
    public class ColliderData
    {
        public Vector3 center;
        public float height;
    }
    public ColliderData ColliderDataIsGrounded = new ColliderData();
    public ColliderData ColliderDataNotGrounded = new ColliderData();
    #endregion Variables

    private void Start()
    {

    }
    private void OnEnable()
    {
        InvokeRepeating("VerifyYPosition", 0, VerifyYPositionRate);
    }

    private void Update()
    {
        CheckIfGrounded();
    }
      
    private void CheckIfGrounded()
    {      
        RaycastHit hit;
        Vector3 raycastOrigin = transform.position;
        Vector3 targetPosition;
        targetPosition = transform.position;
        raycastOrigin.y = raycastOrigin.y + raycastHeightOffset;

        if (!isGrounded && !jumping)
        {           
            AddFallingForce();
        }
        if (Physics.SphereCast(raycastOrigin, 0.2f, -Vector3.up, out hit, groundLayer))
        {           
            Vector3 rayCastHitPoint = hit.point;
            targetPosition.y = rayCastHitPoint.y;
            inAirTimer = 0;
            isGrounded = true;

            distance = rayCastHitPoint.y - raycastOrigin.y;

            Debug.DrawLine(raycastOrigin, targetPosition, Color.blue);


            if (distance < 0.6f)
            {
                SetGrounded();
            }
            else
            {
                SetNotGrounded();
            }           
        }
        else
        {
    
        }            
    }

    void VerifyYPosition()
    {
    //    if (!isGrounded) { 
            Vector3 raycastOrigin = transform.position;
            raycastOrigin.y = raycastOrigin.y + raycastHeightOffset;

            if (yPosition == raycastOrigin.y)
            {
                SetGrounded();
            }
            else
            {
                SetNotGrounded();
            }

            yPosition = raycastOrigin.y;   
    //    }
    }

    void SetGrounded()
    {
        inAirTimer = 0;

        isGrounded = true;

        _animator.SetBool("InAir", false);
    //   CancelInvoke("SetColliderToIsGrounded");
     //   CancelInvoke("SetColliderToNotGrounded");
    //    Invoke("SetColliderToIsGrounded", colliderDelay);
    }

    void SetNotGrounded()
    {
        isGrounded = false;

        _animator.SetBool("InAir", true);
     //   CancelInvoke("SetColliderToIsGrounded");
     //   CancelInvoke("SetColliderToNotGrounded");
        //    Invoke("SetColliderToNotGrounded", colliderDelay);

    }

    void AddFallingForce()
    {
        inAirTimer = inAirTimer + Time.deltaTime;
        m_rigidbody.AddForce(transform.forward * leapingVelocity);
        m_rigidbody.AddForce(-Vector3.up * fallingVelocity * inAirTimer);
    }

    public void SetColliderToIsGrounded()
    {
        collider.center = ColliderDataIsGrounded.center;
        collider.height = ColliderDataIsGrounded.height;
    }

    public void SetColliderToNotGrounded()
    {
        collider.center = ColliderDataNotGrounded.center;
        collider.height = ColliderDataNotGrounded.height;
    }


    #region Damages & death
    void OnCollisionEnter(Collision collision) // object is collided by anther object, verify if the other is an ennemy bullet
    {
        ProjectileController bulletController = collision.transform.GetComponent<ProjectileController>();
        EnnemyController ennemyController = collision.transform.GetComponent<EnnemyController>();

        if (LifePoint > 0)
        {
            // verify if the collision is an entering ennemy bullet
            if (bulletController != null)
            {
                Debug.Log("LifePoint > 0 OnCollisionEnter bulletController");
                // Receive damages from the bullet                  
                ReceiveDamages(bulletController.GetDamages());
            } 
            else if(IsPlayer && ennemyController != null)
            {
                ReceiveDamages(ennemyController.enemyData._collisionDamages);
            }
        }
        else
        {
            // resurrection
        }
    }

    public void ReceiveDamages(int damages) // the object receives damages from a colliding ennemy bullet
    {
        Debug.Log("ReceiveDamages");
        // verify if the object is not invincible
        if (MaxLifePoint != -1)
        {
            // kill / destroy self at 0 life point left
            if (LifePoint - damages <= 0)
            {
                LifePoint = 0;

                if (playerController == null)
                    playerController = FindObjectOfType<PlayerController>();

                // verify if the object is a turret
                if (transform != null
                    && playerController != null
                    && playerController.transform != null
                    && playerController.transform != transform)
                {
                    // TODO invoke event

                }
                DestroySelf();
            }
            // apply damages amount
            else
            {
                LifePoint = LifePoint - damages;
            }

            // TODO update UI about life points
        /*    if (IsPlayer)
                uiManager.SetLifePointsDisplay(LifePoint);
            else if (healthbar != null)
                healthbar.UpdateHealthBar(LifePoint);
        */
        }
    }

    void DestroySelf() // destroy itself and depending objects
    {
        if (IsPlayer)
        {
            animator.CrossFade("Die", 0.2f);
            GetComponent<AudioSource>()?.Play();
            EventManager.TriggerEvent(EventManager.Events.OnPlayerDeath);
            Invoke("Destroying", 2f);
            
        }
        else
        {
            if (HowDestroy == HowDestroyEnum.DestroyObject)
            {
                Destroying();
            }
            else if (HowDestroy == HowDestroyEnum.DisableComponent)
            {
                this.enabled = false;
            }
        }
        InstantiateFXForDestruction();
        PlayDestructionSound();
    }

    void Destroying()
    {
        Destroy(gameObject);
    }

    void InstantiateFXForDestruction()
    {
        if (enemyData != null && enemyData._fXSpawnerDestroyedObjPrefab != null)
        {
            // Instantiate the particle system at the impact position
            GameObject spawner = Instantiate<GameObject>(enemyData._fXSpawnerDestroyedObjPrefab, DestroyedFXPositionObj.transform.position,
               DestroyedFXPositionObj.transform.rotation);
        }
    }

    void PlayDestructionSound()
    {
        if (DestroyedSoundPlayer != null)
        {
            DestroyedSoundPlayer.enabled = true;
            DestroyedSoundPlayer.Stop();
            DestroyedSoundPlayer.loop = false;
            if (enemyData != null)           
                DestroyedSoundPlayer.PlayOneShot(enemyData._destroyedSound);
            else if (IsPlayer == true)
                DestroyedSoundPlayer.PlayOneShot(transform.GetComponent<PlayerController>()._playerData._destroyedSound);
        }

    }
    #endregion Damages & death
}
