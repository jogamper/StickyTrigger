using System.Collections.Generic;
using UnityEngine;

namespace Bees
{
    public class BeeManger : MonoBehaviour
    {
        public GameObject beeFab;

        private List<GameObject> bees;
        // Start is called before the first frame update
        void Start()
        {
            bees = new List<GameObject>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    GameObject bee = Instantiate(beeFab);
                    bee.transform.parent = transform;
                    var localScale = beeFab.transform.localScale;
                    bee.transform.position = new Vector3(-5 + j * (localScale.x * 1.5f),
                        i * (localScale.y * 1.5f));
                    bees.Add(bee);
                }
            }
            AddBoundsToAllChildren();
        }
        private void AddBoundsToAllChildren()
        {

            var boxCol = gameObject.GetComponent<BoxCollider2D>();
            if (boxCol == null)
            {
                boxCol = gameObject.AddComponent<BoxCollider2D>();
            }

            Bounds bounds = new Bounds(transform.position, Vector3.zero);

            var allDescendants = gameObject.GetComponentsInChildren<Transform>();
            foreach (Transform desc in allDescendants)
            {
                Renderer childRenderer = desc.GetComponent<Renderer>();
                if (childRenderer != null)
                {
                    bounds.Encapsulate(childRenderer.bounds);
                }
                boxCol.offset = bounds.center - transform.position;
                boxCol.size = bounds.size;
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
