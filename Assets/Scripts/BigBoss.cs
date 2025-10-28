using UnityEngine;

public class BigBoss : Enemy
{
    private Animator animator;

    [Header("Teleport Settings")]
    [SerializeField] private float skillCooldown = 5f; 
    [SerializeField] private float teleportDelay = 0.8f; 
    private float nextSkillTime = 0f;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        nextSkillTime = Time.time + skillCooldown;
    }

    protected override void Update()
    {
        base.Update();
        if (Time.time > nextSkillTime)
        {
            StartTeleport();
        }
    }

    protected override void FlipEnemy()
    {
        if (player != null)
        {
            transform.localScale = new Vector3(
                player.transform.position.x < transform.position.x ? 1 : -1,
                1,
                1
            );
        }
    }
    private void StartTeleport()
    {
        nextSkillTime = Time.time + skillCooldown; 

        if (animator != null)
        {
            animator.SetBool("Istele", true); 
        }
        Invoke(nameof(DoTeleport), teleportDelay);
    }

    private void DoTeleport()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }

        if (animator != null)
        {
            animator.SetBool("Istele", false);
        }
        Invoke(nameof(StartAttackAfterTeleport), 0.2f);
    }

    private void StartAttackAfterTeleport()
    {
        if (animator != null)
        {
            animator.SetBool("Isattack", true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Isattack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Isattack", false);
        }
    }

    private void DealDamage()
    {
        player.TakeDamage(30);
    }
}
