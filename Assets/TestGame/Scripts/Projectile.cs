
using UnityEngine;

namespace Unicorn
{
    public class Projectile : MonoBehaviour
    {
        
        
        void Start()
        {

        }

        
        void Update()
        {
            transform.Translate(Vector3.right * Time.deltaTime * 10);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.root.TryGetComponent<Enemy>(out var enemy))
            {
                
                enemy.Hited();
                

                Destroy(gameObject);
            }
            
        }
       
    }
}
