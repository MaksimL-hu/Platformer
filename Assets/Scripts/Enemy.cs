using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;

    private int _currentPoint = 0;

    private void Update()
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, _points[_currentPoint].position, _speed * Time.deltaTime);
        
        if(newPosition.x > transform.position.x) 
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);

        transform.position = newPosition;

        if (transform.position == _points[_currentPoint].position)
            NextPoint();

    }

    private void NextPoint()
    {
        _currentPoint = ++_currentPoint % _points.Length;
    }
}