using Bees;
using UnityEngine;

public class  Projectile : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed *Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bee"))
        {
            var bee = collision.gameObject;
            Destroy(bee);
            Destroy(gameObject);
            BeeManger.instance.UpdateBoundsByChildren();
        }

        if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}