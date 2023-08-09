
using UnityEngine;
using TMPro;
using Spine.Unity;
using UnityEngine.SceneManagement;

namespace Unicorn
{
    public class Player : MonoSingleton<Player>
    {
        [SerializeField] Projectile projectile;
        [SerializeField] Transform shootPoint;

        public int totalEnemies;
        public int enemiesKilled=0;
        [SerializeField] public TMP_Text enemyText;

        SkeletonAnimation skeletonAnimation;

        public bool isLoose = false;

        [SerializeField] private GameObject victory;
        [SerializeField] private GameObject loose;

       

        void Start()
        {
            skeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
            skeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
        }


        void Update()
        {
            if(!isLoose) transform.Translate(Vector3.right * Time.deltaTime * 2);

            enemyText.text = "”ничтожено врагов: " + enemiesKilled.ToString() + "/" + totalEnemies.ToString();

            if (Input.GetMouseButtonDown(0))
            {
                

                

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,Mathf.Infinity,2);

               

                if (hit!=null&&hit.transform.root.TryGetComponent<Enemy>(out var enemy))
                    {
                    
                        Instantiate(projectile, shootPoint.transform.position, Quaternion.identity);
                        skeletonAnimation.AnimationState.SetAnimation(0, "shoot", false);
                        skeletonAnimation.AnimationState.AddAnimation(0, "walk", true,1);


                }


                

            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.root.TryGetComponent<Enemy>(out var enemy))
            {
                Debug.Log("hit enemy trigger");
                enemy.Win();
                skeletonAnimation.AnimationState.SetAnimation(0, "loose", false);
                isLoose = true;
                loose.gameObject.SetActive(true);


            }

            if (collision.transform.name=="crypt")
            {
                skeletonAnimation.AnimationState.SetAnimation(0, "idle", true);
                isLoose = true;
                victory.gameObject.SetActive(true);
            }

        }

        public void ReastartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
