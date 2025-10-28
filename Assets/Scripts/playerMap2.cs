using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class playerMap2 : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriterenderer;
    private Animator animator;
    [SerializeField] private float maxHp = 100f;
    private float currentHp;
    [SerializeField] private Image HpBar;
    [SerializeField] private GameManagerMap2 gamemanager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        currentHp = maxHp;
        UpdateHpBar();

    }


    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamemanager.PauseGameMenu();
        }
    }
    void MovePlayer()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = playerInput.normalized * MoveSpeed;
        if (playerInput.x < 0)
        {
            spriterenderer.flipX = true;
        }
        else if (playerInput.x > 0)
        {
            spriterenderer.flipX = false;
        }
        if (playerInput != Vector2.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }
    public void TakeDamage(float damage)
    {

        currentHp -= damage;
        currentHp = Mathf.Max(currentHp, 0);
        UpdateHpBar();
        if (currentHp <= 0)
        {
            Die();
        }
    }
    public void Heal(float HealValue)
    {
        if (currentHp < maxHp)
        {
            currentHp += HealValue;
            currentHp = Mathf.Min(currentHp, maxHp);
            UpdateHpBar();
        }
    }
    public void Die()
    {
        gamemanager.GameOverMenu();
    }
    public void UpdateHpBar()
    {
        if (HpBar != null)
        {
            HpBar.fillAmount = currentHp / maxHp;
        }
    }

}
