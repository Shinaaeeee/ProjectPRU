using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyEL : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] protected float enemyMoveSpeed = 1f;
    [SerializeField] protected float maxHp = 50f;
    [SerializeField] protected float enterDamage = 10f;
    [SerializeField] protected float stayDamage = 1f;
    [SerializeField] private Image hpBar;

    protected PlayerEL player;
    protected float currentHp;

    [Header("Auto HP Increase")]
    [SerializeField] private float hpIncreaseInterval = 10f;  // Tăng mỗi 10 giây
    [SerializeField] private float hpIncreaseRate = 1.1f;     // Tăng 10%
    private float timer = 0f;

    // ================================
    // LIFECYCLE
    // ================================
    protected virtual void Start()
    {
        player = FindAnyObjectByType<PlayerEL>();
        currentHp = maxHp;
        UpdateHpBar();
    }

    protected virtual void Update()
    {
        MoveToPlayer();
        HandleHpIncreaseOverTime();
    }

    // ================================
    // CORE BEHAVIORS
    // ================================
    protected void MoveToPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.transform.position,
                enemyMoveSpeed * Time.deltaTime
            );
            FlipEnemy();
        }
    }

    protected virtual void FlipEnemy()
    {
        if (player != null)
        {
            transform.localScale = new Vector3(
                player.transform.position.x < transform.position.x ? -1 : 1,
                1,
                1
            );
        }
    }

    public virtual void TakeDamage(float damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Max(currentHp, 0);
        UpdateHpBar();
        if (currentHp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    protected void UpdateHpBar()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = currentHp / maxHp;
        }
    }

    // ================================
    // NEW: AUTO HP INCREASE SYSTEM
    // ================================
    protected virtual void HandleHpIncreaseOverTime()
    {
        timer += Time.deltaTime;
        if (timer >= hpIncreaseInterval)
        {
            timer = 0f;
            IncreaseHp();
        }
    }

    protected virtual void IncreaseHp()
    {
        maxHp *= hpIncreaseRate;       // tăng 10%
        currentHp = maxHp;             // hồi đầy máu
        UpdateHpBar();
        Debug.Log($"{gameObject.name} tăng HP lên {maxHp}");
    }
}
