using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float scale = 0.3f;
    [SerializeField] private float attackDistance;

    private Animator _animator;
    private Rigidbody2D _rb;
    private GameObject _player;
    private float _lastAttackTime = 0.0f; // Time of the last attack

    // Start is called before the first frame update
    void Start() {
        _player = GameObject.Find("Player");
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Time.time - _lastAttackTime < attackCooldown) return;
        if (_player == null) return;

        // Calculate the direction from the enemy to the player
        var position = transform.position;
        Vector3 direction = _player.transform.position - position;

        if (direction.magnitude < attackDistance && Time.time - _lastAttackTime >= attackCooldown) {
            Attack();
            return;
        }
        
        _rb.velocity = direction.normalized * speed;
        _animator.SetFloat("Speed", direction.magnitude);
        
        // Flip the enemy sprite based on the direction
        
        if(direction.x < 0) {
            transform.localScale = new Vector3(-scale, scale, scale);
        } else {
            transform.localScale = new Vector3(scale,scale,scale);
        }
    }
    private void Attack() {
        Debug.Log("Attacking player");
        _animator.SetFloat("Speed", 0f);
        _animator.SetTrigger("attack_trigger");
        _lastAttackTime = Time.time;
        _rb.velocity = Vector2.zero;
        // todo overlap attack area.         
    }
}