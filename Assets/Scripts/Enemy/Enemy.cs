using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _reloadAttack;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private Player _target;
    [SerializeField] private float _detectionDistance;
    [SerializeField] private float _attackDistance;
    [SerializeField] private GroundDetector _wallDetector;
    [SerializeField] private GroundDetector _groundDetector;

    private float _lastTimeAttack;

    private void Update()
    {
        _lastTimeAttack += Time.deltaTime;

        if (_wallDetector.IsGround)
        {
            if (_groundDetector.IsGround)
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

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Destroy(gameObject);
    }

    private void Attack()
    {
        _target.TakeDamage(_damage);
    }
}