using UnityEngine;
using UnityEngine.SceneManagement;
public class playercollisionMap1 : MonoBehaviour
{
    [SerializeField] GameManager manager;
    [SerializeField] private AudioManager audioManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            player player = GetComponent<player>();
            player.TakeDamage(10f);
        }
        else if (collision.CompareTag("Usb"))
        {
            SceneManager.LoadScene("Map2");
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Energy"))
        {
            manager.AddEnergy();
            Destroy(collision.gameObject);
            audioManager.PlayEnergySound();
        }
    }
}