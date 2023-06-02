using System;
using UnityEngine;

namespace Banana
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;
        
        private static readonly int Move1 = Animator.StringToHash("speed");
        private static readonly int Attack1 = Animator.StringToHash("Attack");
        private static readonly int Shoot1 = Animator.StringToHash("Shoot");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Move(float value)
        {
            _animator.SetFloat(Move1, value);
        }

        public void Attack()
        {
            _animator.Play(Attack1);
        }

        public void Shoot()
        {
            _animator.SetTrigger(Shoot1);
        }
    }
}