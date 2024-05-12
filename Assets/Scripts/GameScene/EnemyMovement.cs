using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private float attackCooldown = 0.5f;

    private GameObject _player;
    private float _lastAttackTime = 0.0f; // Time of the last attack

    // Start is called before the first frame update
    void Start() {
        _player = GameObject.Find("Player");
    }

    private void Update() {
        if (Time.time - _lastAttackTime < attackCooldown) return;
        if (_player == null) return;

        // Calculate the direction from the enemy to the player
        var position = transform.position;
        Vector3 direction = _player.transform.position - position;

        if (direction.magnitude < 1 && Time.time - _lastAttackTime >= attackCooldown) {
            Attack();
            _lastAttackTime = Time.time;
            return;
        }

        // Normalize the direction vector to maintain constant speed
        direction.Normalize();

        // Move the enemy towards the player
        position += direction * (speed * Time.deltaTime);
        transform.position = position;
    }

    private void Attack() {
        Debug.Log("Attacking player");
    }
}