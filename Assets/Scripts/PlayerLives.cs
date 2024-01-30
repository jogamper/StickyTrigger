using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;

    public Image[] livesUI;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Bee"))
        {
            Destroy(collision.collider.gameObject);
            UpdateLives();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(collision.gameObject);
            UpdateLives();
        }
    }

    private void UpdateLives()
    {
        lives -= 1;
        for (var i = 0; i < livesUI.Length; i++)
            if (i < lives)
                livesUI[i].enabled = true;
            else
                livesUI[i].enabled = false;

        if (lives <= 0) GameManager.instance.RestartGame();
        // Destroy(gameObject);
    }
}