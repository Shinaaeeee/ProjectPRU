using UnityEngine;
using UnityEngine.UI;
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed = 1f;
    protected player player;
    [SerializeField] protected float maxHp = 50f;
    protected float currentHp;
    [SerializeField] private Image hpBar;

    [SerializeField] protected float enterDamage = 10f;
    [SerializeField] protected float stayDamage = 1f;


    protected virtual void Start()
    {
        player = FindAnyObjectByType<player>();
        currentHp= maxHp;
        UpdateHpBar();
    }
    protected virtual void Update()
    {
        MoveToPlayer();
    }
    protected  void MoveToPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position,enemyMoveSpeed*Time.deltaTime);
            FlipEnemy();
        }
    }
    protected virtual void FlipEnemy()
    {
        if (player != null) {
            transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
        }
    }
    public virtual void TakeDamage( float damage)
    {
        currentHp-=damage;
        currentHp=Mathf.Max(currentHp,0);
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
        if (hpBar != null) {
            hpBar.fillAmount = currentHp / maxHp;
        }
    }
}

