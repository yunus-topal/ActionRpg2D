using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters.Enemy {
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(EnemyStatus))]
    public class EnemyMovement : MonoBehaviour {

        private Animator _animator;
        private EnemyStatus _enemyStatus;
        private Enemy _enemy;
        private GameObject _player;
        private float _lastAttackTime = 0.0f; // Time of the last attack
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int AttackTrigger = Animator.StringToHash("attack_trigger");
        private static readonly int AttackType = Animator.StringToHash("attack_type");

        // Start is called before the first frame update
        void Start() {
            _player = GameObject.Find("Player");
            _animator = GetComponent<Animator>();
            _enemyStatus = GetComponent<EnemyStatus>();
            _enemy = _enemyStatus.Enemy;
        }

        private void Update() {
            if (Time.time - _lastAttackTime < _enemy.AttackCooldown) return;
            if (_player == null) return;

            // Calculate the direction from the _enemy to the player
            var position = transform.position;
            Vector3 direction = _player.transform.position - position;

            if (direction.magnitude < _enemy.AttackDistance && Time.time - _lastAttackTime >= _enemy.AttackCooldown) {
                Attack();
                return;
            }
        
            // move towards to player
            transform.position += direction.normalized * (_enemy.Speed * Time.deltaTime);
            // rotate towards to player on z axis
            // transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        
            _animator.SetFloat(Speed, direction.magnitude);
            
            // Flip the _enemy sprite based on the direction
            transform.localScale = direction.x < 0 ? new Vector3(-1, 1, 1) : new Vector3(1,1,1);
        }
        private void Attack() {
            Debug.Log("Attacking player");
            _animator.SetFloat(Speed, 0f);
            _animator.SetInteger(AttackType, Random.Range(0, 2));
            _animator.SetTrigger(AttackTrigger);
            _lastAttackTime = Time.time;
            // todo overlap attack area.  
            
        }
        
    }
}