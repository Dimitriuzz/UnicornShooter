using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

namespace Unicorn
{
    public class Enemy : MonoBehaviour
    {
        


   

        SkeletonAnimation skeletonAnimation;
        Spine.AnimationState animationState;
        Spine.Skeleton skeleton;

        void Awake()
        {
            skeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
            skeleton = skeletonAnimation.Skeleton;
            
            animationState = skeletonAnimation.AnimationState;
        }
        // Start is called before the first frame update
        void Start()
        {
                skeletonAnimation.AnimationState.SetAnimation(0, "run", true);
            }

        // Update is called once per frame
        void Update()
        {
            //transform.Translate(Vector3.left * Time.deltaTime * 5);
        }

        public void Hited()
        {
            Player.Instance.enemiesKilled++;
            skeletonAnimation.AnimationState.SetAnimation(0, "angry", true);

            }
    }
}
