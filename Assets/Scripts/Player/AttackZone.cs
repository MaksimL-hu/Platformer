using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    [SerializeField] private Player _player;

    private List<Enemy> _enemies = new List<Enemy>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            _enemies.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            _enemies.Remove(enemy);
    }

    public Enemy GetNearestEnemy()
    {
        if (_enemies.Count == 0)
            return null;

        Enemy nearestEnemy = _enemies[0];

        foreach (var enemy in _enemies)
            if (Vector3.Distance(enemy.transform.position, _player.transform.position) < Vector3.Distance(nearestEnemy.transform.position, _player.transform.position))
                nearestEnemy = enemy;

        return nearestEnemy;
    }
}