
using UnityEngine;

namespace Bees
{
    public class BeeMovement : MonoBehaviour
    {
        public float moveSpeed;
     
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Boundary"))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                moveSpeed *= -1;
            }
        }
    }
}
