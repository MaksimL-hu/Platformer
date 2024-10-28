using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _reloadAttack;
    [SerializeField] private AttackZone _attackZone;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerAnimator _playerAnimator;

    [SerializeField] private float _lastTimeAttack;

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
            _mover.Move(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
            _playerAnimator.PlayJumpAnimation();
        }
    }

    private void Update()
    {
        _lastTimeAttack += Time.deltaTime;

        if (_inputReader.GetIsAttack() && _lastTimeAttack >= _reloadAttack)
        {
            _lastTimeAttack = 0;

            if(_attackZone.Enemy != null)
                Attack(_attackZone.Enemy);
        }

    }

    private void Attack(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public void Heal(int health)
    {
        _health += health;
    }
}