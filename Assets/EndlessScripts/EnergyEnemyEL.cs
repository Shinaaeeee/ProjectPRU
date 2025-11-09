using UnityEngine;

public class EnergyEnemyEL : EnemyEL
{
    [SerializeField] private GameObject energyObject;

    private GameManagerEL gm;

    protected override void Start()
    {
        base.Start(); // gọi Start() của EnemyEL để HP và thanh HP khởi tạo đúng
        gm = FindAnyObjectByType<GameManagerEL>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(enterDamage);
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
        // Spawn năng lượng
        if (energyObject != null)
        {
            GameObject energy = Instantiate(energyObject, transform.position, Quaternion.identity);
            Destroy(energy, 5f);
        }

        // Tăng điểm
        if (gm != null)
        {
            gm.AddScore(10);
        }

        base.Die(); // vẫn gọi logic chết mặc định
    }
}
