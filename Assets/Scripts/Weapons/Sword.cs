using UnityEngine;

public class Sword : Weapon, IRepair
{
    [SerializeField] PlayerAnimations m_playerAnimations;
    /*
    public override void Attack()
    {
        // Catches enemy in front of the player and kill them
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 2f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Enemy>().TakeDamage(10f);
            }

        }
        m_playerAnimations.Attack();
    }
    */
    public void Repair()
    {
        // life += 50;
    }
}
