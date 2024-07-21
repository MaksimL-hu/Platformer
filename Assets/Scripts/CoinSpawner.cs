using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private Coin _prefab;

    private Coin _coin;

    private void Awake()
    {
        SpawnCoin();
    }

    private void SpawnCoin()
    {
        if (_coin != null)
            _coin.Collected -= SpawnCoin;

        _coin = Instantiate(_prefab, _points[Random.Range(0, _points.Length)]);
        _coin.Collected += SpawnCoin;
    }
}