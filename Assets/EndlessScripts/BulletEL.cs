using UnityEngine;

public class BulletEL : MonoBehaviour
{
    [SerializeField] private float moveSpeedBullet = 25f;
    [SerializeField] private float timeDestroy = 0.5f;
    [SerializeField] private float damage = 10f;
    [SerializeField] GameObject BloodPrefabs;

    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }


    void Update()
    {
        moveBullet();
    }
    void moveBullet()
    {
        transform.Translate(Vector2.right * moveSpeedBullet * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyEL enemy = collision.GetComponent<EnemyEL>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                GameObject blood = Instantiate(BloodPrefabs, transform.position, Quaternion.identity);
                Destroy(blood, 1f);
            }
            Destroy(gameObject);
        }
    }
}
