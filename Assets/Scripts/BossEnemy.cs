using UnityEngine;
using UnityEngine.SceneManagement;


public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform firepoint;
    [SerializeField] private float speedDanthuong = 20f;
    [SerializeField] private float SpeedDanVongtron = 10f;
    [SerializeField] private float hpValue = 100f;
    [SerializeField] private GameObject miniEnemy;
    [SerializeField] private float skillCooldown = 2f;
    private float nextSkillTime = 0f;
    [SerializeField] private GameObject UsbPrefabs;
    [SerializeField] private GameObject WinPrefab;
    protected override void Update()
    {
        base.Update();
        if (Time.time > nextSkillTime)
        {
            SuDungSkill();
        }
    }
    public override void Die()
    {
        GameManager gameManager = FindAnyObjectByType<GameManager>();

        // ✅ Chỉ cộng điểm khi đang ở chế độ sinh tồn
        if (gameManager != null && gameManager.isSurvivalMode)
        {
            gameManager.AddScore(10); // <-- điểm Boss, tùy bạn đổi
        }



        if (SceneManager.GetActiveScene().name == "Map1")
        {
            Instantiate(UsbPrefabs, transform.position, Quaternion.identity);
        }
        else if(SceneManager.GetActiveScene().name == "Map2")
                {
            Instantiate(WinPrefab, transform.position, Quaternion.identity);
        }
        base.Die();
    }
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
    private void BanDanThuong()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.transform.position - firepoint.position;
            directionToPlayer.Normalize();
            GameObject bullet = Instantiate(bulletPrefabs, firepoint.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(directionToPlayer * speedDanthuong);
        }
    }
    private void BanDanVongTron()
    {
        const int bulletCount = 12;
        float angleStep = 360f / bulletCount;
        for (int i = 0; i < bulletCount; i++) {
            float angle = i * angleStep;
            Vector3 bulletDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle),0);
            GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            EnemyBullet enemyBullet= bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(bulletDirection*SpeedDanVongtron);
                }

    }
    private void HoiMau(float HpAmount)
    {
        currentHp=Mathf.Min(currentHp+ HpAmount,maxHp);
        UpdateHpBar();
    }
    private void SinhminiEnemy()
    {
        Instantiate(miniEnemy,transform.position, Quaternion.identity);
    }
    private void DichChuyen()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }
    private void ChonSkillNgauNhien()
    {
        int randomSkill = Random.Range(0, 5);
        switch (randomSkill)
        {
            case 0:
                BanDanThuong();
                break;
            case 1:
                BanDanVongTron();
                break;
            case 2:
                HoiMau(hpValue);
                break;
            case 3:
                SinhminiEnemy();
                break;
            case 4:
                DichChuyen();
                break;
        }

    }
    private void SuDungSkill()
    {
        nextSkillTime = Time.time + skillCooldown;
        ChonSkillNgauNhien();
    }
}

