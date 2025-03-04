using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    private List<Enemy> _enemies = new List<Enemy>();

    public Enemy Enemy
    {
        get 
        { 
            if(_enemies.Count == 0)
                return null;

            return _enemies[0];
        }
        private set { }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _enemies.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _enemies.Remove(enemy);
        }
    }
}