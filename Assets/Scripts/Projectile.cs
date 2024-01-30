using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bee"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Bees.BeeManager.instance.UpdateBoundsByChildren();
        }
        else if (collision.gameObject.CompareTag("Boundary")) Destroy(gameObject);
    }
}