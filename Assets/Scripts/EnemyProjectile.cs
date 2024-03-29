using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary")) Destroy(gameObject);
    }
}