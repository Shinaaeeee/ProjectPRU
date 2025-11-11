using UnityEngine;

public class BasicEnemyEL : EnemyEL
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(enterDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(stayDamage);
        }
    }

    public override void Die()
    {
        // ✅ tìm GameManager EL
        GameManagerEL gm = FindAnyObjectByType<GameManagerEL>();

        if (gm != null)
        {
            gm.AddScore(10); // bạn chỉnh điểm tùy ý
        }

        base.Die(); // vẫn xóa enemy, hiệu ứng... từ class cha
    }

}
