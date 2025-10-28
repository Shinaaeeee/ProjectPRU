using UnityEngine;

public class BasicHero : Enemy 
{
    private Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { 
        animator = GetComponent<Animator>();
        animator.SetBool("Isattack", true);
    }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator = GetComponent<Animator>();
            animator.SetBool("Isattack", false);
        }
    }
    private void DealDamage()
    {
        player.TakeDamage(20f);
    }

}

