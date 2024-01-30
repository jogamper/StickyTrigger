using UnityEngine;

public class ProjectileShoot : MonoBehaviour

{
    public GameObject projectileFab;
    public float shotsPerSecond = 1f;
    private float time = 0;

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
        if (1 / shotsPerSecond < time)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(projectileFab,
                                    new Vector3(transform.position.x, transform.position.y + 1, transform.position.z),
                                    Quaternion.identity);
                time = 0;
            }
        }
    }
}