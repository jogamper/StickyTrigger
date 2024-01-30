
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
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Boundary"))
            {
                var position = transform.position;
                position =
                    new Vector3(position.x, position.y - 0.5f, position.z);
                transform.position = position;
                moveSpeed *= -1;
            }
        }
    }
}
