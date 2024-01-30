using System.Collections.Generic;
using UnityEngine;

namespace Bees
{
    public class BeeManger : MonoBehaviour
    {
        public static BeeManger instance;
        public GameObject beeFab;

        public int rows = 3;
        public int cols = 6;

        public float spacing = 0.5f;
        
        private void Awake()
        {
            if (instance != null && instance != this)
                Destroy(this);
            else
                instance = this;
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
            if (boxCol == null) boxCol = gameObject.AddComponent<BoxCollider2D>();
            var bounds = new Bounds(transform.position, Vector3.zero);
            var allDescendants = gameObject.GetComponentsInChildren<Transform>();
            foreach (var desc in allDescendants)
            {
                var childRenderer = desc.GetComponent<Renderer>();
                if (childRenderer != null) bounds.Encapsulate(childRenderer.bounds);
                boxCol.offset = bounds.center - transform.position;
                boxCol.size = bounds.size;
            }
        }
    }
}