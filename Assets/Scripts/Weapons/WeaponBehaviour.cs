using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour, IAttackWeapon
{
    #region Variables

    [SerializeField]
    InputManager.InputsEnum FireInput = InputManager.InputsEnum.Fire1; 

    [SerializeField]
    CharacterController characterController;

    [SerializeField]
    WeaponData weaponData;

    [SerializeField]
    bool Locked = true;

    [Serializable]
    public class ProjectileSpawnerData
    {
        public GameObject BulletSpawner;
        public GameObject FireFXDirection;
    }

    [SerializeField]
    protected List<ProjectileSpawnerData> ProjectileSpawnersList = new List<ProjectileSpawnerData>();

    private float _timeSinceLastShot;
    #endregion Variables

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnEnable()
    {      
        Unlock();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAttack();
    }

    void UpdateAttack()
    {
        bool attackInput = Input.GetButtonDown(FireInput.ToString());
        if (attackInput && characterController._equipWeapon != null && characterController._equipWeapon.GetSpawnedObject() != null)
        {
            Fire(characterController);
        }
    }

    public void Fire(CharacterController _characterController)
    {
        characterController = _characterController;

        if (Locked == false)
        {
            Lock();
            fireProjectile();
            Invoke("Unlock", weaponData._fireRate);
        }
    }

    public void ByPlayer(CharacterController _characterController)
    {
        characterController = _characterController;
    }
    public void Unlock()
    {
        Locked = false;
    }
    public void Lock()
    {
        Locked = true;
    }

    private void fireProjectile()
    {
        for (int i = 0; i < ProjectileSpawnersList.Count; i++)
        {
            Debug.Log(i);
            InstantiateBulletPrefab(ProjectileSpawnersList[i]);
        }
        Unlock();
    }
    private IEnumerator fireProjectile2()
    {
        for (int i = 0; i < ProjectileSpawnersList.Count; i++)
        {
            InstantiateBulletPrefab(ProjectileSpawnersList[i]);
        }
        yield return new WaitForSeconds(60f/(weaponData._fireRate/* * GameHandler.Instance.ComboMultipl*/));
        Unlock();
    }

    protected void InstantiateBulletPrefab(ProjectileSpawnerData bulletSpawner) // create the bullet
    {
        if (bulletSpawner != null)
        {
            // Create a bullet and place it on the correct trajectory
            GameObject bullet = Instantiate<GameObject>(weaponData._projectilePrefab, bulletSpawner.BulletSpawner.transform.position, bulletSpawner.BulletSpawner.transform.rotation);
            ProjectileController bulletController = bullet.transform.GetComponent<ProjectileController>();
            bulletController.emiter = bulletSpawner.BulletSpawner;
            bulletController.dirObj = bulletSpawner.FireFXDirection;

            bullet.gameObject.SetActive(true);

            // display ammo count on the UI
            if (characterController._IsPlayer)
            {
                bulletController.FiredBy = ProjectileController.FiredByEnum.Player;
            }
            else bulletController.FiredBy = ProjectileController.FiredByEnum.Enemy;
        }
    }
}
