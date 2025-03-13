using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _reloadAttack;

    [SerializeField] private VampirismAbility _vampirism;

    [SerializeField] private Health _health;
    [SerializeField] private AttackZone _attackZone;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerCollisionDetector _collisionDetector;

    private float _lastTimeAttack;
    private float _lastTimeVampirism;

    private void OnEnable()
    {
        _collisionDetector.MedKitCollected += Heal;
    }

    private void OnDisable()
    {
        _collisionDetector.MedKitCollected -= Heal;
    }

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
        _lastTimeVampirism += Time.deltaTime;

        if (_inputReader.GetIsAttack() && _lastTimeAttack >= _reloadAttack)
        {
            _lastTimeAttack = 0;

            if(_attackZone.GetNearestEnemy() != null)
                Attack(_attackZone.GetNearestEnemy());
        }

        if(_inputReader.GetIsVampirism())
        {
            _vampirism.Vampirism();
        }
    }

    private void Attack(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
    }

    public void Heal(float health)
    {
        _health.Heal(health);
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }
}