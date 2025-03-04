using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _minHealth = 0;
    private float _currentHealth;

    public event Action HealthChanged;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke();
    }

    public void Heal(float health)
    {
        if (health < 0)
            return;

        _currentHealth = Mathf.Clamp(_currentHealth + health, _minHealth, _maxHealth);
        HealthChanged?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        _currentHealth = Mathf.Clamp(_currentHealth - damage, _minHealth, _maxHealth);
        HealthChanged?.Invoke();
    }
}