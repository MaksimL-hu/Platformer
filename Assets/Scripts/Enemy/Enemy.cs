using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _mover;

    private void Update()
    {
        _mover.Move();
    }
}