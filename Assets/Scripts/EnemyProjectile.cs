using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        transform.Translate(Vector2.down * speed * Time.deltaTime);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}

