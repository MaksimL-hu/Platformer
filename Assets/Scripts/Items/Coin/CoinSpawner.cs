using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private Coin _prefab;

    private int _previousPoint;

    private void Start()
    {
        SpawnCoin();
    }

    public void SpawnCoin()
    {
        Instantiate(_prefab, _points[GetNextRandomPoint()]);
    }

    private int GetNextRandomPoint()
    {
        int point = Random.Range(0, _points.Length);

        if (point == _previousPoint)
            if (point + 1 == _points.Length)
                point = 0;
            else
                point++;

        _previousPoint = point;

        return point;
    }
}