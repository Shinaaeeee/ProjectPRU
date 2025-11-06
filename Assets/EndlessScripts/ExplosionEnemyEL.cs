using UnityEngine;

public class ExplosionEnemyEL : EnemyEL
{
    [SerializeField] private GameObject explotionObject;
    private void CreateExplotion()
    {
        if (explotionObject != null)
        {
            Instantiate(explotionObject, transform.position, Quaternion.identity);
        }
    }

    public override void Die()
    {
        CreateExplotion();
        base.Die();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CreateExplotion();
            Die();
        }

    }


}
