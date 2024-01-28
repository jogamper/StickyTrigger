
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float hInput;
   

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * hInput * moveSpeed *Time.deltaTime);

    }
}


