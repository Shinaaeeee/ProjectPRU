using UnityEngine;

public class HealEnemyEL : EnemyEL
{
    [SerializeField] private float healvalue = 10f;

    private GameManagerEL gm;

    protected override void Start()
    {
        base.Start();
        gm = FindAnyObjectByType<GameManagerEL>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            player.TakeDamage(enterDamage);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            player.TakeDamage(stayDamage);
    }

    public override void Die()
    {
        HealPlayer();

        if (gm != null)
            gm.AddScore(10);

        base.Die();
    }

    private void HealPlayer()
    {
        if (player != null)
            player.Heal(healvalue);
    }
}
