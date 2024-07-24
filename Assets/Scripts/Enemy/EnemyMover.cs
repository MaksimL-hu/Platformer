using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;

    private int _currentPoint = 0;

    public float DirectionX {  get; private set; }

    public void Move()
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, _points[_currentPoint].position, _speed * Time.deltaTime);

        DirectionX = newPosition.x - transform.position.x;
        transform.position = newPosition;

        if (transform.position == _points[_currentPoint].position)
            GetNextPoint();
    }

    private void GetNextPoint()
    {
        _currentPoint = ++_currentPoint % _points.Length;
    }
}