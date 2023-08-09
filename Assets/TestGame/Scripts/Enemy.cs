
using UnityEngine;
using Spine.Unity;

namespace Unicorn
{
    public class Enemy : MonoBehaviour
    {


        [SerializeField] GameObject hitEffect;


        SkeletonAnimation skeletonAnimation;
        

        void Awake()
        {
            skeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
            
            
            
        }

        void Start()
        {
                skeletonAnimation.AnimationState.SetAnimation(0, "run", true);
            }


        void Update()
        {
            if (!Player.Instance.isLoose) transform.Translate(Vector3.left * Time.deltaTime * 3);
            //else Win();
        }

        public void Win()
        {
            skeletonAnimation.AnimationState.SetAnimation(0, "win", true);
        }
        public void Hited()
        {
            Player.Instance.enemiesKilled++;
            skeletonAnimation.AnimationState.SetAnimation(0, "angry", true);
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.5f);
        }
    }
}
