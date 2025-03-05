using UnityEngine;

public class EnemyDestroyer : Destroyer
{
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.DamageTaken += TryDestroyEnemy;
    }

    private void OnDisable()
    {
        _enemy.DamageTaken -= TryDestroyEnemy;
    }

    private void TryDestroyEnemy()
    {
        if (_enemy.CurrentHealth <= 0)
            DestroyObject();
    }

    protected override void DestroyObject()
    {
        base.DestroyObject();
    }
}