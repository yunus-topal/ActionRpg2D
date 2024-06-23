using System;
using UnityEngine;

namespace Characters.Enemy {
    
    [RequireComponent(typeof(Animator))]
    public class EnemyStatus : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;
        public Enemy Enemy => enemy;
        
        private int _currHealth;
        private Animator _animator;
        private static readonly int HitTrigger = Animator.StringToHash("hit_trigger");

        private void Start() {
            _animator = GetComponent<Animator>();
            if(enemy == null) {
                throw new NullReferenceException("Enemy is not set in the inspector!");
            }
            _currHealth = enemy.MaxHealth;
        }

        public void TakeDamage(int damage = 0) {
            _currHealth -= damage;
            _animator.SetTrigger(HitTrigger);
            if (_currHealth <= 0) {
                // start dying animation in the future
                Death();
            }
        }
        
        public void Death() {
            // play death animation
            //_animator.SetTrigger("isDead", true);
            Destroy(gameObject);
        }
    }
}
