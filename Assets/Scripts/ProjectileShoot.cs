
using UnityEngine;

public class ProjectileShoot : MonoBehaviour

{
    public GameObject projectileFab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectileFab, transform.position, Quaternion.identity);
        }
    }
}
