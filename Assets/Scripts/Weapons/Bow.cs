using UnityEngine;
using System.Collections;

public class Bow : Weapon, IRepair
{
    [Space(10)]
    [SerializeField] GameObject m_projectilePrefab;

 /*   public override void Attack()
    {
        StartCoroutine(ProjectileCoroutine());
    }
    */
    public void Repair()
    {
        // répare l'arme
    }

    private IEnumerator ProjectileCoroutine()
    {
        GameObject projectile = Instantiate(m_projectilePrefab, transform.position + transform.forward, Quaternion.identity);

        Vector3 direction = transform.forward;
        float distance = 0f;

        // Move the projectile forward until it hits an enemy or reaches max distance
        while (distance < 10f)
        {
            float advancement = 10f * Time.deltaTime;
            projectile.transform.position += direction * advancement;
            distance += advancement;

            if (Physics.Raycast(projectile.transform.position, direction, out RaycastHit hit, 0.5f))
            {
                // Hitting enemy
                if (hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<Enemy>().TakeDamage(5f);
                }

                // if hitting anything, destroy projectile
                break;
            }

            yield return null;
        }

        Destroy(projectile);
    }
}
