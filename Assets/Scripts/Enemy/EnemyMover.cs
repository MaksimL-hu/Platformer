using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform[] _points;
    [SerializeField] private Rigidbody2D _rigidbody;

    private int _currentPoint = 0;

    public float DirectionX {  get; private set; }

    public void MoveToPoint()
    {
        MoveTo(_points[_currentPoint].position);

        if (transform.position == _points[_currentPoint].position)
            GetNextPoint();
    }

    public void MoveTo(Vector3 position)
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, position, _speed * Time.deltaTime);
        DirectionX = newPosition.x - transform.position.x;
        transform.position = newPosition;
    }

    public void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, _jumpForce));
    }

    private void GetNextPoint()
    {
        _currentPoint = ++_currentPoint % _points.Length;
    }
}