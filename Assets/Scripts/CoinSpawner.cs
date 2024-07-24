using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private Coin _prefab;
    [SerializeField] private PlayerCollisionDetector _playerCollisionDetector;

    private void Start()
    {
        SpawnCoin();
    }

    public void SpawnCoin()
    {
        Instantiate(_prefab, _points[Random.Range(0, _points.Length)]);
    }
}