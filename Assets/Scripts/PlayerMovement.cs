using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("Attack Directions")] [SerializeField]
    private GameObject attackBack;

    [SerializeField] private GameObject attackFront;
    [SerializeField] private GameObject attackLeft;
    [SerializeField] private GameObject attackRight;


    [Header("Stats")] [SerializeField] private float speed;
    [SerializeField] private float attackCooldown = 0.5f;

    // private fields
    private float _lastAttackTime = 0.0f; // Time of the last attack
    private Rigidbody2D _rb;
    private Animator _animator;

    // animation hashes
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int AttackTrigger = Animator.StringToHash("attack_trigger");

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * speed;

        _rb.velocity = movement;

        _animator.SetFloat(Speed, movement.magnitude);

        if (movement != Vector2.zero) {
            _animator.SetFloat(Horizontal, movement.x);
            _animator.SetFloat(Vertical, movement.y);
        }

        if (Input.GetKey(KeyCode.Mouse0) && Time.time - _lastAttackTime >= attackCooldown) {
            _animator.SetTrigger(AttackTrigger);
            _lastAttackTime = Time.time;
        }
    }

    public void Attack(int attackDirection) {
        Collider2D[] hitColliders;
        switch (attackDirection) {
            case 0:
                // take 0.6 radius around the back 
                hitColliders = Physics2D.OverlapCircleAll(attackBack.transform.position, 0.6f);
                break;
            case 1:
                // take 0.6 radius around the right
                hitColliders = Physics2D.OverlapCircleAll(attackRight.transform.position, 0.6f);
                break;
            case 2:
                // take 0.6 radius around the front
                hitColliders = Physics2D.OverlapCircleAll(attackFront.transform.position, 0.6f);
                break;
            case 3:
                // take 0.6 radius around the left
                hitColliders = Physics2D.OverlapCircleAll(attackLeft.transform.position, 0.6f);
                break;
            default:
                hitColliders = Array.Empty<Collider2D>();
                break;
        }

        foreach (var collider in hitColliders) {
            // TODO: Add damage to the enemy
        }
    }
}