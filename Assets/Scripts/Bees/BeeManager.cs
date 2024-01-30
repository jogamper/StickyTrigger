using System.Collections.Generic;
using UnityEngine;

namespace Bees
{
    public class BeeManager : MonoBehaviour
    {
        public static BeeManager instance;
        public GameObject beeFab;

        public int rows = 3;
        public int cols = 6;

        public float spacing = 0.5f;
        
        private void Awake()
        {
            // make it a singelton
            if (instance == null)
                instance = this;
            else if (instance != this)
                // singleton: there can only ever be one instance of a GameManager.
                Destroy(gameObject);
        }

        // Start is called before the first frame update
        private void Start()
        {
            for (var i = 0; i < rows; i++)
            for (var j = 0; j < cols; j++)
            {
                var localScale = beeFab.transform.localScale;
                var bee = Instantiate(beeFab, new Vector3(-(cols) + j * (localScale.x + spacing),
                     (rows-1)+ i * (localScale.y + spacing)), Quaternion.identity);
                bee.transform.parent = transform;
            }
            UpdateBoundsByChildren();
        }

        // Update is called once per frame
        private void Update()
        {
            if (transform.childCount == 0)
            {
                GameManager.instance.RestartGame();
            }
        }

        public void UpdateBoundsByChildren()
        {
            var boxCol = gameObject.GetComponent<BoxCollider2D>();
            var bounds = new Bounds(transform.position, Vector3.zero);
            var allDescendants = gameObject.GetComponentsInChildren<Transform>();
            foreach (var desc in allDescendants)
            {
                var childRenderer = desc.gameObject.GetComponent<SpriteRenderer>();
                if (childRenderer != null) bounds.Encapsulate(childRenderer.bounds);
                boxCol.offset = bounds.center - transform.position;
                boxCol.size = bounds.size;
            }
        }
    }
}