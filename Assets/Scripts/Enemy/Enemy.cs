using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _reloadAttack;
    [SerializeField] private float _detectionDistance;
    [SerializeField] private float _attackDistance;

    [SerializeField] private Health _health;
    [SerializeField] private Player _target;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private GroundDetector _wallDetector;
    [SerializeField] private GroundDetector _groundDetector;

    public event Action DamageTaken;

    public float CurrentHealth => _health.CurrentHealth;

    private float _lastTimeAttack;

    private void FixedUpdate()
    {
        _lastTimeAttack += Time.deltaTime;

        if (_wallDetector.IsGround && _groundDetector.IsGround)
        {
            _mover.Jump();

            return;
        }

        if (Vector3.Distance(_target.transform.position, transform.position) < _detectionDistance)
        {
            if (Vector3.Distance(_target.transform.position, transform.position) < _attackDistance && _lastTimeAttack >= _reloadAttack)
            {
                Attack();
                _lastTimeAttack = 0;
            }

            _mover.MoveTo(_target.transform.position);

            return;
        }

        _mover.MoveToPoint();
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);

        DamageTaken?.Invoke();
    }

    private void Attack()
    {
        _target.TakeDamage(_damage);
    }
}