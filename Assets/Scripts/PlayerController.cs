using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float hInput;


    // Update is called once per frame
    private void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * hInput * moveSpeed * Time.deltaTime);
        if (hInput < 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        else if (hInput > 0) gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
}