using UnityEngine;

public class ExplosionEL : MonoBehaviour
{
    [SerializeField] private float Damage = 25f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerEL player = collision.GetComponent<PlayerEL>();
        EnemyEL enemy = collision.GetComponent<EnemyEL>();
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(Damage);

        }
        if (collision.CompareTag("Enemy"))
        {
            enemy.TakeDamage(Damage);

        }
    }
    public void DestroyExplotion()
    {
        Destroy(gameObject);
    }
}
