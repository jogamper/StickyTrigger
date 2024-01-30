using UnityEngine;

namespace Bees
{
    public class ProjectileSpawner : MonoBehaviour
    {
        public GameObject enemyProjectile;
        private float spawnTimer;
        public float spawnMax = 30;
        public float spawnMin = 15;
        private float time;

        // Start is called before the first frame update
        private void Start()
        {
            spawnTimer = Random.Range(1, spawnMax);
        }

        // Update is called once per frame
        private void Update()
        {
            time += Time.deltaTime;
            if (spawnTimer < time)
            {
                Instantiate(enemyProjectile, transform.position, Quaternion.identity);
                spawnTimer = Random.Range(spawnMin, spawnMax);
                time = 0;
            }
            
        }
    }
}