using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unicorn
{
    public class Player : MonoSingleton<Player>
    {
        [SerializeField] Projectile projectile;
        [SerializeField] Transform shootPoint;

        public int totalEnemies;
        public int enemiesKilled;


        void Start()
        {

        }


        void Update()
        {
            //transform.Translate(Vector3.right * Time.deltaTime * 5);

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("pressed");

                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                
                //RaycastHit hit;

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,Mathf.Infinity,2);

                Debug.Log(hit.transform.name);

                if (hit.transform.root.TryGetComponent<Enemy>(out var enemy))
                    {
                    Debug.Log("hit");
                        Instantiate(projectile, shootPoint.transform.position, Quaternion.identity);

                    }


                

            }
        }
    }
}
