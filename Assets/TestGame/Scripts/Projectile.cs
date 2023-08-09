using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unicorn
{
    public class Projectile : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.right * Time.deltaTime * 10);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("hit something");
            if (collision.transform.root.TryGetComponent<Enemy>(out var enemy))
            {
                Debug.Log("hit enemy");
                Destroy(gameObject);
            }
        }
    }
}
