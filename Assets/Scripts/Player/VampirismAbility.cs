using System;
using System.Collections;
using UnityEngine;

public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AttackZone _attackZone;
    [SerializeField] private float _reloadVampirism;
    [SerializeField] private float _timeAttackVampirism;
    [SerializeField] private float _speedStealingHealth;

    private bool _isReload = true;

    public event Action OnStealingHealth;
    public event Action OnReloading;

    public float ReloadVampirism => _reloadVampirism;
    public float TimeAttackVampirism => _timeAttackVampirism;

    private void StealHealth(Enemy enemy, float health)
    {
        enemy.TakeDamage(health);
        _player.Heal(health);
    }

    private IEnumerator StealingHealth()
    {
        Enemy enemy;
        float time = 0f;

        OnStealingHealth?.Invoke();

        while (time < _timeAttackVampirism)
        {
            enemy = _attackZone.GetNearestEnemy();
            time += Time.deltaTime;

            if (enemy != null)
                StealHealth(enemy, _speedStealingHealth * Time.deltaTime);

            yield return null;
        }

        StartCoroutine(Reloading());
    }

    private IEnumerator Reloading()
    {
        float time = 0f;

        OnReloading?.Invoke();

        while (time < _reloadVampirism)
        {
            time += Time.deltaTime;

            yield return null;
        }

        _isReload = true;
    }

    public void Vampirism()
    {
        if (_isReload) 
        {
            _isReload = false;
            StartCoroutine(StealingHealth());
        }
    }
}