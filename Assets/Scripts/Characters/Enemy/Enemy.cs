using UnityEngine;

namespace Characters.Enemy {
    [CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
    public class Enemy : ScriptableObject
    {
        [SerializeField] private string enemyName;
        [SerializeField] private int maxHealth;
        [SerializeField] private int damage;
        [SerializeField] private float attackCooldown;
        [SerializeField] private float attackDistance;
        [SerializeField] private float speed;
        [SerializeField] private GameObject prefab;
        [SerializeField] private Sprite sprite;

        public string EnemyName => enemyName;

        public int MaxHealth => maxHealth;

        public int Damage => damage;

        public float AttackCooldown => attackCooldown;

        public float AttackDistance => attackDistance;

        public float Speed => speed;

        public GameObject Prefab => prefab;

        public Sprite Sprite => sprite;
    }
}
