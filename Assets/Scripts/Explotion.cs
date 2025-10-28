using UnityEngine;

public class Explotion : MonoBehaviour
{
    [SerializeField] private float Damage = 25f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player player= collision.GetComponent<player>();
        Enemy enemy = collision.GetComponent<Enemy>();
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
